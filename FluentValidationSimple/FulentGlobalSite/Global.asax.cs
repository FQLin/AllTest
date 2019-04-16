using Autofac;
using FulentGlobalSite.FluentValidation;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;

namespace FulentGlobalSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //autofac
            //IContainer container = Dependency.RegisterType();
            //FluentValidation 注册
            //FluentRegistor.Register(container);
            //ModelValidatorProviders.Providers.Clear();
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
