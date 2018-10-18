using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerMovie.WEB.Models;
using Newtonsoft.Json;
using NLayerMovie.BLL.DTO;
using AutoMapper;
using NLayerMovie.BLL.Services;
using NLayerMovie.BLL.Interfaces;
using System.Data;
using NLayerMovie.WEB.Util;

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
                        var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentPostViewModel, CommentDTO>()).CreateMapper();
                        CommentDTO commentDTO = mapper.Map<CommentPostViewModel, CommentDTO>(postComment);
                        commentService.PostComment(commentDTO);

                        return JsonConvert.SerializeObject(new { postComment.content, postComment.parent, success = true });
                    }
                    return JsonConvert.SerializeObject(new { success = false, message = "Send data is't valid" });
                }
                return JsonConvert.SerializeObject(new { success = false, message = "Login please" });
            }
            catch (DataException ex)
            {
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message});
            }
            
        }

       
        [ValidateAntiForgeryToken]
        public string getComments(int entityType, int entityID)
        {
            try
            {             
                IEnumerable<GetCommentsDTO> commentsDTO =  commentService.GetComments(entityType, entityID);
                IEnumerable<CommentsGetViewModel> commentsGetViewModel = MapperModule.GetCommentsDTO_To_CommentsGetViewModel(commentsDTO);

                return JsonConvert.SerializeObject(new { commentsGetViewModel, success = true });
            }
            catch (DataException ex)
            {
                return JsonConvert.SerializeObject(new { success = false, message = ex.Message });
            }                                      
           

        }      
    }
}