﻿using NLayerMovie.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NLayerMovie.BLL.Interfaces
{
    public interface ICommentService
    {
        void PostComment(CommentDTO commentDto);
        void PostImageComment(CommentImageDTO commentImageDTO);
        IEnumerable<GetCommentsDTO> GetComments(int entityType, int entityID, string userID);
        Task<IEnumerable<GetCommentsDTO>> GetCommentsAsync(int entityType, int entityID, string userID);
        void UpvoteComment(int CommentId, string UserId);
        void EditComment(EditCommentDTO editCommentDTO);
        void Dispose();
    }
}
