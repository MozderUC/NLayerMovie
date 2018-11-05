using System;

namespace NLayerMovie.BLL.DTO
{
    public class EditCommentDTO
    {
        public int id { get; set; }
        public string content { get; set; }
        public DateTime modified { get; set; }
    }
}
