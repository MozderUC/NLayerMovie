using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerMovie.WEB.Models
{
    public class CommentPostViewModel
    {       
        public int entityID { get; set; }
        public int entityType { get; set; }
        public string content { get; set; }
        public int? parent { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}