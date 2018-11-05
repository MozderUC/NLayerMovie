using NLayerMovie.DAL.EF;
using NLayerMovie.DAL.Entities;
using NLayerMovie.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NLayerMovie.DAL.Repositories
{
    class UpvoteRepository : IRepository<Upvote>
    {
        private MovieContext db;

        public UpvoteRepository(MovieContext context)
        {
            this.db = context;
        }

        public IEnumerable<Upvote> GetAll()
        {
            return db.Upvotes;
        }

        public Upvote Get(int id)
        {
            return db.Upvotes.Find(id);
        }

        public void Create(Upvote upvote)
        {
            //var some = db.Comments.Where(item => item.commentEntity.entityType.Equals(1)&&item.commentEntity.entityID.Equals(6)).ToList();

            db.Upvotes.Add(upvote);
        }

        public void Update(Upvote upvote)
        {
            db.Entry(upvote).State = EntityState.Modified;
        }

        public IEnumerable<Upvote> Find(Func<Upvote, Boolean> predicate)
        {
            return db.Upvotes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Upvote upvote = db.Upvotes.Find(id);
            if (upvote != null)
                db.Upvotes.Remove(upvote);
        }
    }
}
