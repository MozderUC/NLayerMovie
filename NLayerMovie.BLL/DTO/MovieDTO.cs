
using System;

namespace NLayerMovie.BLL.DTO
{
    public class MovieDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int GenreID { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        
    }
}
