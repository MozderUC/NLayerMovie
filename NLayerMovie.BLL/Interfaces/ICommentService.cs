using NLayerMovie.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovie.BLL.Interfaces
{
    public interface ICommentService
    {
        void PostComment(CommentDTO commentDto);
        IEnumerable<GetCommentsDTO> GetComments(int entityType, int entityID);
    }
}
