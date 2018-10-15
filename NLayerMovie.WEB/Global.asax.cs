using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using NLayerMovie.BLL.Infrastructure;
using NLayerMovie.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NLayerMovie.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule movieModule = new MovieModule();
            NinjectModule serviceModule = new ServiceModule("NlayerMovie");
            var kernel = new StandardKernel(movieModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}
