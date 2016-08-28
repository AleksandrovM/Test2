using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplicationT4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MvcApplicationT4.Controllers" }
            );

            routes.MapRoute("NewRoute", "App/Do{action}",
                new { controller = "Home" });

            //routes.MapRoute(null, "Public/{controller}/{action}",
            //   defaults: new { action = "Countries", controller = "Home" });


            //routes.MapRoute(
            //    name: "MyRoute",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = "DefaultId" }
            //    );

            //routes.MapRoute("MyRoute3", "{controller}/{action}",
            // defaults: new { action = "Index" }
            // //, namespaces: new[] { "MvcApplicationT4.aa.Controllers" }

            //);// 

            //routes.MapRoute("MyRoute2", "{controller}/{action}",
            //    defaults: new { action = "Index" }
            //    , namespaces: new[] { "MvcApplicationT4.Controllers" } 
            //   );// 

          

            //routes.MapRoute("ind2", "ind2");


 
        }
    }
}