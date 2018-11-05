using NLayerMovie.DAL.EF;
using NLayerMovie.DAL.Entities;
using NLayerMovie.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NLayerMovie.DAL.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private MovieContext db;

        public GenreRepository(MovieContext context)
        {
            this.db = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres;
        }

        public Genre Get(int id)
        {
            return db.Genres.Find(id);
        }

        public void Create(Genre genre)
        {
            db.Genres.Add(genre);
        }

        public void Update(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
        }

        public IEnumerable<Genre> Find(Func<Genre, Boolean> predicate)
        {
            return db.Genres.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre != null)
                db.Genres.Remove(genre);
        }
    }
}
