using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace hairdressing_schedule
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "UpdateClient",
                url: "Client/{Id}/UpdateClient",
                defaults: new { controller = "Client", action = "UpdateClient", UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteClient",
                url: "Client/{Id}/DeleteClient",
                defaults: new { controller = "Client", action = "DeleteClient", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "UpdateCrew",
                url: "Crew/{Id}/UpdateCrew",
                defaults: new { controller = "Crew", action = "UpdateCrew", UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteCrew",
                url: "Crew/{Id}/DeleteCrew",
                defaults: new { controller = "Crew", action = "DeleteCrew", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
