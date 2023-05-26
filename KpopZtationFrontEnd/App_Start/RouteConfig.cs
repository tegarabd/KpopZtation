using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace KpopZtationFrontEnd.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            FriendlyUrlSettings settings = new FriendlyUrlSettings
            {
                AutoRedirectMode = RedirectMode.Permanent
            };

            routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute("home", "", "~/View/Home.aspx");
            routes.MapPageRoute("login", "login", "~/View/Login.aspx");
            routes.MapPageRoute("register", "register", "~/View/Register.aspx");
            routes.MapPageRoute("profile", "profile", "~/View/Profile.aspx");
            routes.MapPageRoute("transaction", "transaction", "~/View/Transaction.aspx");
            routes.MapPageRoute("cart", "cart", "~/View/Carts.aspx");
            routes.MapPageRoute("report", "report", "~/View/Reports.aspx");

        }
    }
}