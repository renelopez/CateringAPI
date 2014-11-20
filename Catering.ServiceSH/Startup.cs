using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Autofac;
using Autofac.Integration.WebApi;
using Catering.Data.DataLayer;
using Catering.Data.Migrations;
using Catering.ServiceSH.Config;
using Newtonsoft.Json.Serialization;
using Owin;

namespace Catering.ServiceSH
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            var cors = new EnableCorsAttribute("*", "*", "*") { SupportsCredentials = true };
            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );

            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Creating the builder.
            var builder = new ContainerBuilder();

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

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CateringContext, Configuration>());
            appBuilder.UseWebApi(config);
        }
    }
}
