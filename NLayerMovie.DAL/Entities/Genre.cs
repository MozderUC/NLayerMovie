using System.Collections.Generic;

namespace NLayerMovie.DAL.Entities
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
