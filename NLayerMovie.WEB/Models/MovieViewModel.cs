using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerMovie.WEB.Models
{
    public class MovieViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int GenreID { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}