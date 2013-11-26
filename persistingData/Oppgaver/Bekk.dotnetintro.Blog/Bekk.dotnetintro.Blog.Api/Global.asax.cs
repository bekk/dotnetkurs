using System;
using System.Web.Http;
using Bekk.dotnetintro.Blog.DependencyResolution;
using WebApiContrib.IoC.StructureMap;
using Bekk.dotnetintro.Blog.Data.Migrations;
using System.Configuration;

namespace Bekk.dotnetintro.Blog
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var config = GlobalConfiguration.Configuration;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new StructureMapResolver(ApiContainer.Configure());

            Migrate.MigrateToLatestVersion(ConfigurationManager.ConnectionStrings["BlogDataConnectionString"].ConnectionString);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}