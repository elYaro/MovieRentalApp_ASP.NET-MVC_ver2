using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieRentalApp_ASP.NET_MVC_ver2._2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            /*
         in order to sent multiple parapeters in URL we need costom routes to do so we need to ass custom routes in RoutesConfig.
         We can use the old scool method below or the new method above (routes.MapMvcAttributeRoutes();). Both are presented in RoutesConfig.cs
        

            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate" },
                new { year = @"\d{4}", month = "\\d{2}" });
            //example of another CONSTRAINTS to year to 2012 or 2013
            //new { year = @"2012|2013", month = "\\d{2}" });
         */




            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
