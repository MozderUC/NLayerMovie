using AutoMapper;
using NLayerMovie.BLL.DTO;
using NLayerMovie.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovie.BLL.Infrastructure
{
    public static class MapperModule
    {
        public static IEnumerable<GetCommentsDTO> Comment_To_GetCommentsDTO(IEnumerable<Comment> comments)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, GetCommentsDTO>()
                .ForMember("creator", opt => opt.MapFrom(src => src.commentEntity.userID))
                .ForMember("fullname", opt => opt.MapFrom(src => src.commentEntity.user.Name))
                .ForMember("content", opt => opt.MapFrom(src => src.context))
                .ForMember("id", opt => opt.MapFrom(src => src.ID)))
                .CreateMapper();


            IEnumerable<GetCommentsDTO> commentsDTO = mapper.Map<IEnumerable<Comment>, IEnumerable<GetCommentsDTO>>(comments);

            return commentsDTO;

        }

        public static CommentEntity CommentDTO_To_CommentEntity(CommentDTO commentDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentEntity>()).CreateMapper();
            CommentEntity commentEntity = mapper.Map<CommentDTO, CommentEntity>(commentDTO);

            return commentEntity;
        }

        public static Comment CommentDTO_To_Comment(CommentDTO commentDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, Comment>()
                .ForMember("context", opt => opt.MapFrom(src => src.content)))
                .CreateMapper();
            Comment comment = mapper.Map<CommentDTO, Comment>(commentDTO);

            return comment;
        }



    }
}
