using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovie.DAL.Entities
{
    public class CommentImage
    {
        [Key]
        [ForeignKey("comment")]
        public int ID { get; set; }

        public int contentLength { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
        public byte[] data { get; set; }

        public Comment comment { get; set; }
    }
}
