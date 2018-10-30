using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovie.DAL.Interfaces
{
    public interface ICommentRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        Task<List<T>> FindAsync(int entityType, int entityID);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
