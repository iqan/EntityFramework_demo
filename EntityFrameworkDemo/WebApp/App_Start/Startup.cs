﻿using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(WebApp.App_Start.Startup))]
namespace WebApp.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}