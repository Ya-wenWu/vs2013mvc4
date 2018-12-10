﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //定義*.axd格式的網址不透過asp.net mvc的routing來處理
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}