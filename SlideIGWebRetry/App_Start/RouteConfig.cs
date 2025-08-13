using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SlideIGWebRetry
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Details",
                url: "details/{id}/{type}/{lang}",
                defaults: new { controller = "Details", action = "Index"}
            );


            routes.MapRoute(
                name: "Edit",
                url: "edit/{id}/{type}/{lang}",
                defaults: new { controller = "Edit", action = "Index" }
            );

            routes.MapRoute(
                name: "NewBlank",
                url: "newblank",
                defaults: new { controller = "newblank", action = "Index" }
            );

            routes.MapRoute(
                name: "NewCopy",
                url: "newcopy/{id}/{type}/{lang}",
                defaults: new { controller = "newcopy", action = "Index" }
            );

        }
    }
}
