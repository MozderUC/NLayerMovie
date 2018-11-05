using System;
using System.ComponentModel.DataAnnotations;

namespace NLayerMovie.WEB.Models
{
    public class CommentImagePostViewModel
    {
        [Required]
        public int entityID { get; set; }
        [Required]
        public int entityType { get; set; }

        public int contentLength { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
        public byte[] data { get; set; }

        public int? parent { get; set; }
        [Required]
        public DateTime created { get; set; }
        [Required]
        public DateTime modified { get; set; }
    }
}