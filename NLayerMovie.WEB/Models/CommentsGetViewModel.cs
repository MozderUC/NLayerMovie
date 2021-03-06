﻿using System;
using System.ComponentModel.DataAnnotations;

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
        public int upvote_count { get; set; }
        public bool created_by_current_user { get; set; }
        public bool user_has_upvoted { get; set; }
        [Required]
        public string content { get; set; }
        public string file_url { get; set; }
        public string file_mime_type { get; set; }
        public int? parent { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}