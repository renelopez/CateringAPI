using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Catering.Data.DataLayer;
using Newtonsoft.Json.Serialization;

namespace Catering.Service.Config
{
    public class DIConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Get your HTTP Configuration
            var config = GlobalConfiguration.Configuration;

         
            // Register your Web API controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register<DbContext>((_) => new CateringContext());
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<DishRepository>().As<IDishRepository>();

            // Set the dependency resolver to be Autofac
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DbConfiguration.Loaded +=
                (s, e) => e.AddDependencyResolver(new AutoFacDBDependencyResolver(container), false);

        }
    }
}