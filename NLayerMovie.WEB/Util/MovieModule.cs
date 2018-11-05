using Ninject.Modules;
using NLayerMovie.BLL.Interfaces;
using NLayerMovie.BLL.Services;

namespace NLayerMovie.WEB.Util
{
    public class MovieModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMovieService>().To<MovieService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}