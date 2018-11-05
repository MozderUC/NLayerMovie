using NLayerMovie.DAL.Entities;
using NLayerMovie.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace NLayerMovie.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Movie> Movies { get; }
        IRepository<Genre> Genres { get; }
        ICommentRepository<Comment> Comments { get; }
        IRepository<Upvote> Upvotes { get; }
        void Save();

        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();        
    }
}
