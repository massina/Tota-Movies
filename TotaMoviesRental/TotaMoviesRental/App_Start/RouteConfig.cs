using System.Web.Mvc;
using System.Web.Routing;

namespace TotaMoviesRental
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "MoviesByReleaseDate",
            //    url: "{controller}/{action}/{year}/{month}",
            //    defaults: new { controller = "Movies", action = "ByReleaseDate" },
            //    constraints: new { year = @"\d{4}", month = @"\d{2}" }

            //    );

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
