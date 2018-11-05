using System;

namespace NLayerMovie.BLL.DTO
{
    public class CommentImageDTO
    {
        public int entityID { get; set; }
        public int entityType { get; set; }
        public string userID { get; set; }

        public int contentLength { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
        public byte[] data { get; set; }

        public int? parent { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}
