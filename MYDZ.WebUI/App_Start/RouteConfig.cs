﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace MYDZ.WebUI.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Front",
                url: "{controller}/{action}.html"
            );

            routes.MapRoute(
                name: "Default",
                url: "{action}",
                defaults: new { controller = "Front", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Order",
                url: "{action}",
                defaults: new { controller = "Front", action = "Index" }
            );
        }
    }
}
