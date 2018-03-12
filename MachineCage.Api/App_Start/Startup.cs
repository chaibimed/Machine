using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using MachineCafe.DataAccess;
using MachineCafe.WebApi.Infrastructure;
using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Ninject.Modules;
using Owin;

[assembly: OwinStartup(typeof(MachineCafe.WebApi.Startup))]

namespace MachineCafe.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            ConfigureRoutes(configuration);
            ConfigureResolver(configuration,app);
            ConfigureFormatter(configuration);
            ConfigureFilters(configuration);
            app.UseWebApi(configuration);
        }

        private void ConfigureFilters(HttpConfiguration configuration)
        {
            configuration.Filters.Add(new InvalidOperationExceptionFilter());
        }

        private void ConfigureFormatter(HttpConfiguration configuration)
        {
            var fjson = configuration.Formatters.JsonFormatter;
            fjson.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void ConfigureResolver(HttpConfiguration config,IAppBuilder app)
        {
            var resolver = new NinjectResolver(new SingletonServiceRegistrations());
            resolver.AddRequestScopedModules(new ScopedServiceRegistration());
            if(app.IsTestingEnvironment())
                resolver.AddRequestScopedModules(new DbContextRegistration());
            config.DependencyResolver = resolver;
        }

        private void ConfigureRoutes(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/user/getReady",
                defaults: new { controller = "cafe" }
            );
        }
    }

    internal class DbContextRegistration : NinjectModule
    {
        public override void Load()
        {
            
            this.Kernel.Bind<ApplicationContext>()
                .ToSelf()
                .WithConstructorArgument("connectionString", "testConnetion");
        }
    }
}
