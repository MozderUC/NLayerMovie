using System;

namespace NLayerMovie.BLL.DTO
{
    public class CommentDTO
    {
        public int entityID { get; set; }
        public int entityType { get; set; }
        public string userID { get; set; }
        public string content { get; set; }
        public int? parent { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}
