using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebAPI.Providers;

[assembly: OwinStartup(typeof(WebAPI.Startup))]

namespace WebAPI
{
    //Every owin application has a statup class which defines the component pipelile.
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
