using NLayerMovie.BLL.DTO;
using NLayerMovie.BLL.Interfaces;
using NLayerMovie.DAL.Entities;
using NLayerMovie.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void PostImageComment(CommentImageDTO commentImageDTO)
        {

            CommentEntity commentEntity = MapperModule.CommentImageDTO_To_CommentEntity(commentImageDTO);

            Comment comment = MapperModule.CommentImageDTO_To_Comment(commentImageDTO);
            CommentImage commentImage = MapperModule.CommentImageDTO_To_CommentImage(commentImageDTO);
            comment.commentEntity = commentEntity;
            comment.commentImage = commentImage;


            Database.Comments.Create(comment);
            Database.Save();
        }


        public async Task<IEnumerable<GetCommentsDTO>> GetCommentsAsync(int entityType, int entityID, string userID)
        {     
            var comments = await Database.Comments.FindAsync(entityType, entityID);
            
            return comments.Select(item => new GetCommentsDTO()
            {
                id = item.ID,
                creator = item.commentEntity.userID,
                fullname = item.commentEntity.user.Name,
                upvote_count = item.Upvote_count,
                created_by_current_user = (item.commentEntity.userID == userID ? true : false),
                user_has_upvoted = item.Upvotes.Where(u => u.UserID.Equals(userID)).Any(),
                content = item.context == null ? "" : item.context,
                file_url = (item.commentImage == null ? null : string.Format("data:{0};base64,{1}", item.commentImage.contentType, Convert.ToBase64String(item.commentImage.data))),
                file_mime_type = (item.commentImage == null ? null : item.commentImage.contentType),
                parent = item.parent,
                created = item.created,
                modified = item.modified
            }
            ).ToList();                           
        }

        public IEnumerable<GetCommentsDTO> GetComments(int entityType, int entityID, string userID)
        {
            using (Database)
            {
                IEnumerable<Comment> comments = Database.Comments.Find(item => item.commentEntity.entityType.Equals(entityType) && item.commentEntity.entityID.Equals(entityID));
                var commentsDTO = comments.Select(item => new GetCommentsDTO()
                {
                    id = item.ID,
                    creator = item.commentEntity.userID,
                    fullname = item.commentEntity.user.Name,
                    upvote_count = item.Upvote_count,
                    created_by_current_user = (item.commentEntity.userID == userID ? true : false),
                    user_has_upvoted = item.Upvotes.Where(u => u.UserID.Equals(userID)).Any(),
                    content = item.context == null ? "" : item.context,
                    file_url = (item.commentImage == null ? null : string.Format("data:{0};base64,{1}", item.commentImage.contentType, Convert.ToBase64String(item.commentImage.data))),
                    file_mime_type = (item.commentImage == null ? null : item.commentImage.contentType),
                    parent = item.parent,
                    created = item.created,
                    modified = item.modified
                }
                ).ToList();

                return commentsDTO;
            }
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

        public void EditComment(EditCommentDTO editCommentDTO)
        {
            Comment comment = Database.Comments.Get(editCommentDTO.id);
            comment.context = editCommentDTO.content;
            comment.modified = editCommentDTO.modified;

            Database.Comments.Update(comment);
            Database.Save();
        }


        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
