﻿using System.Web.Http;
using SearchHelperBot.App_Start;

namespace SearchHelperBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration
                .Formatters.JsonFormatter
                .SerializerSettings.ReferenceLoopHandling = 
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration
                .Formatters.Remove(GlobalConfiguration.Configuration
                    .Formatters.XmlFormatter);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
