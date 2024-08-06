using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using PilotTask_MVC.DataAccess;
using PilotTask_MVC.Services;

namespace PilotTask_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ProfileRepository>()
               .AsSelf()
               .WithParameter("connectionString", connectionString);
            builder.RegisterType<TaskRepository>()
               .AsSelf()
               .WithParameter("connectionString", connectionString);

            builder.RegisterType<ProfileService>()
               .AsSelf();
            builder.RegisterType<TaskService>()
               .AsSelf();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            

        }
    }
}
