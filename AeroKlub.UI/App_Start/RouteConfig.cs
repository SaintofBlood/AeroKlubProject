using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AeroKlub.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,  "",  new { controller = "Login",action = "Login", });
            routes.MapRoute(null, "UserIndex", new { controller = "User", action = "Index" });
      //      routes.MapRoute(null, "AdminIndex", new { controller = "Admin", action = "Index" });
            routes.MapRoute(null, "Rezerwacja", new { controller = "Reservation", Action = "Rezerwacja" });

            routes.MapRoute("DeletePlane", "DeltePlane", new { controller = "Plane", Action = "AddReservation" });
            //  routes.MapRoute("Rezerwacja1", "Rezerwacja1", new { controller = "Reservation", Action = "AddReservation" });
            //  routes.MapRoute("Rezerwacja2", "Rezerwacja2", new { controller = "Reservation", Action = "Create" });

            routes.MapRoute(null, "{controller}/{action}");

        }
    }
}
