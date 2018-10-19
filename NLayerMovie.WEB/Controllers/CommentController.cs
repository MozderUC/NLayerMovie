using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using NLayerMovie.BLL.DTO;
using NLayerMovie.BLL.Interfaces;
using NLayerMovie.WEB.Models;
using NLayerMovie.WEB.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace NLayerMovie.WEB.Controllers
{
    public class CommentController : Controller
    {
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
            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    if (ModelState.IsValid)
                    {
                        this.User.Identity.GetUserId();

                        CommentDTO commentDTO = MapperModule.CommentPostViewModel_To_CommentDTO(postComment);

                        commentDTO.userID = this.User.Identity.GetUserId();
                        commentService.PostComment(commentDTO);

                        return JsonConvert.SerializeObject(new { postComment.content, postComment.parent, success = true });
                    }
                    return JsonConvert.SerializeObject(new { success = false, message = "Send data is't valid" });
                }
                return JsonConvert.SerializeObject(new { success = false, message = "Login please" });
            }
            catch (DataException ex)
            {
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }

        }

        public string postImageComment(CommentImagePostViewModel postImageComment)
        {
            var file = this.Request.Files[0];
            CommentImageDTO commentImageDTO = MapperModule.CommentImagePostViewModel_To_CommentImageDTO(postImageComment);

            commentImageDTO.userID = this.User.Identity.GetUserId();
            commentImageDTO.contentLength = file.ContentLength;
            commentImageDTO.contentType = file.ContentType;
            commentImageDTO.fileName = file.FileName;


            byte[] data = new byte[file.ContentLength];
            file.InputStream.Read(data, 0, file.ContentLength);
            commentImageDTO.data = data;

            commentService.PostImageComment(commentImageDTO);



            //string imageDataURL = string.Format("data:{0};base64,{1}", file.ContentType, Convert.ToBase64String(data));

            string imageBase64Data = Convert.ToBase64String(data);
            string imageDataURL = string.Format("data:{0};base64,{1}", file.ContentType, imageBase64Data);
            return JsonConvert.SerializeObject(new { file_url = imageDataURL, file_mime_type = file.ContentType });


            //if (file != null && file.ContentLength > 0)
            //{
            //    string fname = Path.GetFileName(file.FileName);
            //
            //    postImageComment.fileName = file.FileName;
            //    postImageComment.contentLength = file.ContentLength;
            //    postImageComment.contentType = file.ContentType;
            //
            //    byte[] data = new byte[file.ContentLength];
            //    file.InputStream.Read(data, 0, file.ContentLength);
            //    postImageComment.data = data;
            //
            //    commentService.PostImageComment(postImageComment);
            //
            //
            //    string imageBase64Data = Convert.ToBase64String(data);
            //    string imageDataURL = string.Format("data:{0};base64,{1}", file.ContentType, imageBase64Data);
            //    return JsonConvert.SerializeObject(new { file_url = imageDataURL, file_mime_type = file.ContentType });
            //
            //}
            //return JsonConvert.SerializeObject(new { file_url = "http://www.w3schools.com/html/mov_bbb.mp4", file_mime_type = "video/mp4" });

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
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }


        }

        [ValidateAntiForgeryToken]
        public string upvoteComment(int id)
        {
            try
            {
                string userID = this.User.Identity.GetUserId();
                commentService.UpvoteComment(id, userID);
                return JsonConvert.SerializeObject(new { success = true });
            }
            catch (DataException ex)
            {
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }
        }
    }
}