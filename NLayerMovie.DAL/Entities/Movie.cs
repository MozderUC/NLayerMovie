using System;

namespace NLayerMovie.DAL.Entities
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }      
        public DateTime ReleaseDate { get; set; }
        
        public int GenreID { get; set; }
        public virtual Genre Genre{ get; set; }
    }
}
