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
        public string postComment(CommentPostViewModel postComment)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentPostViewModel, CommentDTO>()).CreateMapper();
                    CommentDTO commentDTO = mapper.Map<CommentPostViewModel, CommentDTO>(postComment);
                    commentService.PostComment(commentDTO);

                    return JsonConvert.SerializeObject(new { postComment.content,postComment.parent, success = true });
                }
                return JsonConvert.SerializeObject(new { success = false });
            }
            return JsonConvert.SerializeObject(new { success = false });
        }

        public string getComments(int entityType, int entityID)
        {                   
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GetCommentsDTO, CommentsGetViewModel>()).CreateMapper();          
            IEnumerable<CommentsGetViewModel> commentsGetViewModel = mapper.Map<IEnumerable<GetCommentsDTO>, IEnumerable<CommentsGetViewModel>>(commentService.GetComments(entityType, entityID));

            return JsonConvert.SerializeObject(commentsGetViewModel);

        }      
    }
}