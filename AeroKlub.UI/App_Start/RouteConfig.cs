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

            //Login //
            routes.MapRoute(null, "NoPermission", new { controller = "Login", action = "NoPermission" });
            routes.MapRoute(null, "Dodajkonto", new { controller = "Login", action = "AddAccount" });
            //Index sites//

            routes.MapRoute(null, "UserIndex", new { controller = "User", action = "Index" });
            routes.MapRoute(null, "AdminIndex", new { controller = "Admin", action = "Index" });
            routes.MapRoute(null, "MechanicIndex", new { controller = "Mechanic", action = "Index" });

            //Admin sites config //

            routes.MapRoute(null, "DodajManualnieSerwis", new { controller = "Admin", action = "AddManuallyService" });
            routes.MapRoute(null, "DodajManualnieUżytkownika", new { controller = "Admin", action = "AddManuallyUser" });
            routes.MapRoute(null, "DodajSamolot", new { controller = "Admin", action = "AddPlane" });
            routes.MapRoute(null, "ZmieńRoleUżytkownika", new { controller = "Admin", action = "ChangeUserRole" });
            routes.MapRoute(null, "UsuńSamolot", new { controller = "Admin", action = "DeletePlane" });
            routes.MapRoute(null, "UsuńSerwis", new { controller = "Admin", action = "DeleteService" });
            routes.MapRoute(null, "UsuńUżytkownika", new { controller = "Admin", action = "DeleteUser" });
            routes.MapRoute(null, "SerwisSamolotów", new { controller = "Admin", action = "PlaneServices" });
            routes.MapRoute(null, "Rezerwacje", new { controller = "Admin", action = "Reservations" });
            routes.MapRoute(null, "Samoloty", new { controller = "Admin", action = "Samoloty" });

            //Mechanic sites config //

            routes.MapRoute(null, "DodajSewisDoSamolotu", new { controller = "Mechanic", action = "AddServiceToPlane" });
            routes.MapRoute(null, "ListaSamolotów", new { controller = "Mechanic", action = "PlaneList" });

            //User sites config //

            routes.MapRoute(null, "TwojeRezerwacje", new { controller = "User", action = "GetHisReservations" });

 
            //Default?

            routes.MapRoute(null, "{controller}/{action}");

            routes.MapRoute(null, "Test", new {controller = "Login" ,  action = "Test" });

        }
    }
}
