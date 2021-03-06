﻿using System;
using System.Collections.Generic;

namespace NLayerMovie.DAL.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        
        public string context { get; set; }
        public int Upvote_count { get; set; }
        public int? parent { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }

        public virtual ICollection<Upvote> Upvotes { get; set; }
        public virtual CommentEntity commentEntity { get; set; }
        public CommentImage commentImage { get; set; }
    }
}
