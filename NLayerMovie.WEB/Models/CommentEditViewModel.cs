﻿using System;

namespace NLayerMovie.WEB.Models
{
    public class CommentEditViewModel
    {
        public int id { get; set; }
        public string content { get; set; }
        public DateTime modified { get; set; }
    }
}