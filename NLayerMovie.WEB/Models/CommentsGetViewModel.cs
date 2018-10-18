using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NLayerMovie.WEB.Models
{
    public class CommentsGetViewModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string creator { get; set; }
        [Required]
        public string fullname { get; set; }
        [Required]
        public string content { get; set; }
        public int? parent { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}