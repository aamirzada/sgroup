using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication1.Core;
using WebApplication1.Interfaces;
using WebApplication1.Service;

namespace WebApplication1
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
            RegisterAutoFac();

            AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

        private void RegisterAutoFac()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterWebApiFilterProvider(config);

            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterType(typeof(MapServerApiReader))
                            .As(typeof(IMapServerReader)).InstancePerRequest();

            builder.RegisterType(typeof(MapServerService))
                            .As(typeof(IMapServerService)).InstancePerRequest();

            var Container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);

        }
    }
}
