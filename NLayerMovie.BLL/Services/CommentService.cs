using AutoMapper;
using NLayerMovie.BLL.DTO;
using NLayerMovie.BLL.Interfaces;
using NLayerMovie.DAL.Entities;
using NLayerMovie.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerMovie.BLL.Infrastructure;

namespace NLayerMovie.BLL.Services
{
    public class CommentService : ICommentService
    {
        IUnitOfWork Database { get; set; }

        public CommentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void PostComment(CommentDTO commentDTO)
        {

            CommentEntity commentEntity = MapperModule.CommentDTO_To_CommentEntity(commentDTO);

            Comment comment = MapperModule.CommentDTO_To_Comment(commentDTO);
            comment.commentEntity = commentEntity;

            Database.Comments.Create(comment);
            Database.Save();
        }

        public IEnumerable<GetCommentsDTO> GetComments(int entityType, int entityID, string userID)
        {
            IEnumerable<Comment> comments = Database.Comments.Find(item => item.commentEntity.entityType.Equals(entityType) && item.commentEntity.entityID.Equals(entityID));

            IEnumerable<GetCommentsDTO> commentsDTO = comments.Select(item => new GetCommentsDTO()
            {
                id = item.ID,
                creator = item.commentEntity.userID,
                fullname = item.commentEntity.user.Name,
                upvote_count = item.Upvote_count,
                created_by_current_user = (item.commentEntity.userID == userID ? true : false),
                user_has_upvoted = item.Upvotes.Where(u => u.UserID.Equals(userID)).Any(),
                content = item.context,
                parent = item.parent,
                created = item.created,
                modified = item.modified
            }          
            );
            
            return commentsDTO;
        }

        public void UpvoteComment(int CommentId, string UserId)
        {
            Comment comment = Database.Comments.Get(CommentId);           
            Upvote Upvote = comment.Upvotes.Where(item => item.UserID.Equals(UserId)).FirstOrDefault();

            if (Upvote == null)
            {
                comment.Upvote_count = comment.Upvote_count + 1;
                comment.Upvotes.Add(new Upvote { CommentID = comment.ID, UserID = UserId, Created = DateTime.Now });

                Database.Comments.Update(comment);
                Database.Save();
                
            }
            else
            {
                comment.Upvote_count = comment.Upvote_count - 1;
                Database.Upvotes.Delete(Upvote.UpvoteID);
                               
                Database.Save();
            }

        }

    }
}
