using NLayerMovie.DAL.EF;
using NLayerMovie.DAL.Entities;
using NLayerMovie.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovie.DAL.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private MovieContext db;

        public MovieRepository(MovieContext context)
        {
            this.db = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            IEnumerable<Movie> all = db.Movies;
            return db.Movies;
        }

        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        public void Create(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
        }

        public IEnumerable<Movie> Find(Func<Movie, Boolean> predicate)
        {
            return db.Movies.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie != null)
                db.Movies.Remove(movie);
        }
    }
}
