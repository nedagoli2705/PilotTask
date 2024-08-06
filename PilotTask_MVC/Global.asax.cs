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
using PilotTask_MVC.Repositories.Interfaces;
using PilotTask_MVC.Services;
using PilotTask_MVC.Services.Interfaces;

namespace PilotTask_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterDependencies();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            

        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            builder.RegisterType<ProfileRepository>()
               .As<IProfileRepository>()
               .WithParameter("connectionString", connectionString);
            builder.RegisterType<TaskRepository>()
               .As<ITaskRepository>()
               .WithParameter("connectionString", connectionString);

            builder.RegisterType<ProfileService>()
               .As<IProfileService>();
            builder.RegisterType<TaskService>()
               .As<ITaskService>();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            
            

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
