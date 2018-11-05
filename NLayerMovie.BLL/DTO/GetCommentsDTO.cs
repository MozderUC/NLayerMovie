using System;

namespace NLayerMovie.BLL.DTO
{
    public class GetCommentsDTO
    {
        

        public int id { get; set; }
        public string creator { get; set; }
        public string fullname { get; set; }
        public int upvote_count { get; set; }
        public bool created_by_current_user { get; set; }
        public bool user_has_upvoted { get; set; }
        
        public string content { get; set; }
        public string file_url { get; set; }
        public string file_mime_type { get; set; }
        public int? parent { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
    }
}
