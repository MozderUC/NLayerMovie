using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerMovie.WEB.Models
{
    public class CommentsGetViewModel
    {
        public int id { get; set; }
        public string creator { get; set; }
        public string fullname { get; set; }

        public string content { get; set; }
        public int? parent { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}