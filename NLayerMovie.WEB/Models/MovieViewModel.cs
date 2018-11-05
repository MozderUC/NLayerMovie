using System;

namespace NLayerMovie.WEB.Models
{
    public class MovieViewModel
    {
        public int ID { get; set; }
        public int entityType
        {
            get
            {
                return 1;
            }
        }
        public string Title { get; set; }
        public int GenreID { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}