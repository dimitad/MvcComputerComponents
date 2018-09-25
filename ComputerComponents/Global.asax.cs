using ComputerComponentsWeb.DI;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ComputerComponentsWeb
{
    public class MvcApplication : HttpApplication
    {
        private static CompDIContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            BootstrapDI();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void BootstrapDI()
        {
            _container = new CompDIContainer();
            IocConfig.RegisterDI(_container);
        }
    }
}
