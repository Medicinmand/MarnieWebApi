using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MarnieWebApi.DbAccess;

namespace MarnieWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var stdb = new DbStation();
            //var result = stdb.GetNearestStation(56.3275, 10.047235);

            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
