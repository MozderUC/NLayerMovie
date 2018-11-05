using NLayerMovie.BLL.Interfaces;
using NLayerMovie.DAL.Repositories;

namespace NLayerMovie.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new EFUnitOfWork(connection));
        }
    }
}
