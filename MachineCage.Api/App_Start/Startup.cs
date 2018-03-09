using System.Web.Http;
using MachineCafe.Api.Infrastructure;
using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
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
            ConfigureResolver(configuration);
            ConfigureFormatter(configuration);
            app.UseWebApi(configuration);
        }

        private void ConfigureFormatter(HttpConfiguration configuration)
        {
            var fjson = configuration.Formatters.JsonFormatter;
            fjson.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void ConfigureResolver(HttpConfiguration config)
        {
            var resolver = new NinjectResolver();
            resolver.AddRequestScopedModules();
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
}
