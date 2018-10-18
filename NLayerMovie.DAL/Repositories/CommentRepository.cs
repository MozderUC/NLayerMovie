using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerMovie.DAL.EF;
using NLayerMovie.DAL.Entities;
using NLayerMovie.DAL.Interfaces;

namespace NLayerMovie.DAL.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        private MovieContext db;

        public CommentRepository(MovieContext context)
        {
            this.db = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments;
        }
        
        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }
        
        public void Create(Comment comment)
        {
            //var some = db.Comments.Where(item => item.commentEntity.entityType.Equals(1)&&item.commentEntity.entityID.Equals(6)).ToList();

            db.Comments.Add(comment);
        }
        
        public void Update(Comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;
        }
        
        public IEnumerable<Comment> Find(Func<Comment, Boolean> predicate)
        {
            return db.Comments.Where(predicate).ToList();
        }
        
        public void Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie != null)
                db.Movies.Remove(movie);
        }
    }
}
