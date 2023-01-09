using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "InitializeDB", action = "InitialiseDB", id = UrlParameter.Optional }
            );

            //routes.MapRoute(

            //    name: "Login",
            //    url: "Home/Login",
            //    defaults: new { controller = "Home", action = "Login"}
            //    );


        }
    }
}
