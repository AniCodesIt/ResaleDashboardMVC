﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ResaleDashboardMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //this was originally controller "Home" and action "Index"
                defaults: new { controller = "VisualizeData", action = "ColumnChart", id = UrlParameter.Optional }
            );
        }
    }
}
