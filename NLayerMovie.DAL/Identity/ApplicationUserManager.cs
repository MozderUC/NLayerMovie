using NLayerMovie.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace NLayerMovie.DAL.Identity
{
    //Данный класс будет управлять пользователями: добавлять их в базу данных и аутентифицировать.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
        
    }
}
