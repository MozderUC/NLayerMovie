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
            CommentEntity commentEntity = new CommentEntity
            {
                userID = "81abf02d-06e8-479d-a722-834284ccaf66",
                entityID = commentDTO.entityID,
                entityType = commentDTO.entityType,
            };

            Comment comment = new Comment
            {
                context = commentDTO.content,
                parent = commentDTO.parent,
                created = commentDTO.created,
                modified = commentDTO.modified,
                commentEntity = commentEntity
            };

            Database.Comments.Create(comment);
            Database.Save();
        }

        public IEnumerable<GetCommentsDTO> GetComments(int entityType, int entityID)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, GetCommentsDTO>()
                .ForMember("creator", opt => opt.MapFrom(src => src.commentEntity.userID))
                .ForMember("fullname", opt => opt.MapFrom(src => src.commentEntity.user.Name))
                .ForMember("content", opt => opt.MapFrom(src => src.context))
                .ForMember("id", opt => opt.MapFrom(src => src.ID)))
                .CreateMapper();
           

            IEnumerable<GetCommentsDTO> commentsDTO = mapper.Map<IEnumerable<Comment>, IEnumerable<GetCommentsDTO>>(Database.Comments.Find(item => item.commentEntity.entityType.Equals(entityType) && item.commentEntity.entityID.Equals(entityID)));
            
            return commentsDTO;
        }
    }
}
