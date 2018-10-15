using Ninject.Modules;
using NLayerMovie.BLL.Interfaces;
using NLayerMovie.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerMovie.WEB.Util
{
    public class MovieModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMovieService>().To<MovieService>();
        }
    }
}