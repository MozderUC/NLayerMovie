using NLayerMovie.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NLayerMovie.DAL.EF
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        static MovieContext()
        {
            Database.SetInitializer<MovieContext>(new StoreDbInitializer());
        }

        public MovieContext() : base("NlayerMovie")
        {
        }
        public MovieContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    class StoreDbInitializer : DropCreateDatabaseIfModelChanges<MovieContext>
    {
        protected override void Seed(MovieContext db)
        {
            db.Movies.Add(new Movie { Title = "Green Mile", ReleaseDate = DateTime.Now });
            db.Movies.Add(new Movie { Title = "Shousheng", ReleaseDate = DateTime.Now });
            db.Movies.Add(new Movie { Title = "Cars", ReleaseDate = DateTime.Now });
            
            db.SaveChanges();
        }
    }
}
