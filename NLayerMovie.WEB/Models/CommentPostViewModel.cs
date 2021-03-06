﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NLayerMovie.WEB.Models
{
    public class CommentPostViewModel
    {
        [Required]
        public int entityID { get; set; }
        [Required]
        public int entityType { get; set; }
        [Required]
        public string content { get; set; }
        public int? parent { get; set; }
        [Required]
        public DateTime created { get; set; }
        [Required]
        public DateTime modified { get; set; }
    }
}