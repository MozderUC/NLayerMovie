using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using NLayerMovie.BLL.DTO;
using NLayerMovie.BLL.Interfaces;
using NLayerMovie.WEB.Models;
using NLayerMovie.WEB.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Web.Mvc;
using System.Configuration;

namespace NLayerMovie.WEB.Controllers
{
    public class CommentController : Controller
    {

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        ICommentService commentService;
        public CommentController(ICommentService serv)
        {
            commentService = serv;
        }
        // GET: Comment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string postComment(CommentPostViewModel postComment)
        {
             if (this.User.Identity.IsAuthenticated)
                {
                    if (ModelState.IsValid)
                    {
                        this.User.Identity.GetUserId();

                        CommentDTO commentDTO = MapperModule.CommentPostViewModel_To_CommentDTO(postComment);

                        commentDTO.userID = this.User.Identity.GetUserId();

                        try
                        {
                            logger.Info("User try add comment");
                            commentService.PostComment(commentDTO);
                            logger.Info("Comment succesfully added");
                        }
                        catch (DbEntityValidationException ex)
                        {
                            logger.Error(ex, "Comment not saved to the Database validation of entities fails");
                            return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
                        }
                        catch(DbUpdateException ex)
                        {
                            logger.Error(ex, "Comment not saved to the Database");
                            return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
                        }
                        catch (DataException ex)
                        {
                            logger.Error(ex, "Comment not saved to the Database");
                            return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
                        }

                        catch (SystemException ex)
                        {
                            logger.Error(ex, "Exeption occured when user post new comment");
                            return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
                        }


                        return JsonConvert.SerializeObject(new { postComment.content, postComment.parent, success = true });
                    }
                    return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = "Send data is't valid" });
                }
                return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = "Login please" });
            }                 

        public string postImageComment(CommentImagePostViewModel postImageComment)
        {
            var file = this.Request.Files[0];

            if(file.ContentType == "image/jpeg"|| file.ContentType == "image/png")
            {
                if (file.ContentLength <= Int32.Parse(ConfigurationManager.AppSettings["MaxFileSize"]))
                {
                    CommentImageDTO commentImageDTO = MapperModule.CommentImagePostViewModel_To_CommentImageDTO(postImageComment);

                    commentImageDTO.userID = this.User.Identity.GetUserId();
                    commentImageDTO.contentLength = file.ContentLength;
                    commentImageDTO.contentType = file.ContentType;
                    commentImageDTO.fileName = file.FileName;

                    byte[] data = new byte[file.ContentLength];
                    file.InputStream.Read(data, 0, file.ContentLength);
                    commentImageDTO.data = data;


                    try
                    {
                        commentService.PostImageComment(commentImageDTO);
                    }
                    catch (DbEntityValidationException ex)
                    {
                        logger.Error(ex, "Comment not saved to the Database validation of entities fails");
                        return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
                    }
                    catch (DbUpdateException ex)
                    {
                        logger.Error(ex, "Comment not saved to the Database");
                        return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
                    }
                    catch (DataException ex)
                    {
                        logger.Error(ex, "Comment not saved to the Database");
                        return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
                    }

                    catch (SystemException ex)
                    {
                        logger.Error(ex, "Exeption occured when user post new comment");
                        return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
                    }
                    string imageBase64Data = Convert.ToBase64String(data);
                    string imageDataURL = string.Format("data:{0};base64,{1}", file.ContentType, imageBase64Data);
                    return JsonConvert.SerializeObject(new { file_url = imageDataURL, file_mime_type = file.ContentType });
                }
                else
                {
                    return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = "File is too big, you can attach file whith size less than 5000 bytes" });
                }
                
            }

            else
            {
                return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = "You can attach only photo in jpeg and png" });
            }
                  

        }

        [ValidateAntiForgeryToken]
        public string getComments(int entityType, int entityID)
        {
            try
            {
                string userID = this.User.Identity.GetUserId();
                IEnumerable<GetCommentsDTO> commentsDTO = commentService.GetComments(entityType, entityID, userID);
                IEnumerable<CommentsGetViewModel> commentsGetViewModel = MapperModule.GetCommentsDTO_To_CommentsGetViewModel(commentsDTO);

                return JsonConvert.SerializeObject(new { commentsGetViewModel, success = true });
            }
            catch (DataException ex)
            {
                logger.Error(ex, "Comments data cannot be retrieved from the database");
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }


        }

        [ValidateAntiForgeryToken]
        public string upvoteComment(int id)
        {
            string userID = this.User.Identity.GetUserId();           

            try
            {
                commentService.UpvoteComment(id, userID);
            }
            catch (DbEntityValidationException ex)
            {
                logger.Error(ex, "Upvote not saved to the Database validation of entities fails");
                return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
            }
            catch (DbUpdateException ex)
            {
                logger.Error(ex, "Upvote not saved to the Database");
                return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
            }
            catch (DataException ex)
            {
                logger.Error(ex, "Upvote not saved to the Database");
                return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
            }

            catch (SystemException ex)
            {
                logger.Error(ex, "Exeption occured when user Upvote comment");
                return JsonConvert.SerializeObject(new ErrorResponse { success = false, message = ex.Message });
            }

            return JsonConvert.SerializeObject(new { success = true });


        }
    }
}