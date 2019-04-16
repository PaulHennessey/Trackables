using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Trackables
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Save",
                url: "{controller}/{action}/{id}/{quantity}/{date}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, quantity = UrlParameter.Optional, date = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Delete",
                url: "{controller}/{action}/{id}/{date}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, date = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
