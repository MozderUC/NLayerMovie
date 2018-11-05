using System;

namespace NLayerMovie.DAL.Entities
{
    public class Upvote
    {
        public int UpvoteID { get; set; }

        public int CommentID { get; set; }
        public string UserID { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual ClientProfile User { get; set; }
        public DateTime Created { get; set; }
    }
}
