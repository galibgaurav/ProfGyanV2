using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Initializing Automapper
            AutoMapperConfig.Initialize();
        }
        protected void Application_Error()
        {

        }

        protected void Application_BeginRequest(Object sender,EventArgs e)
        {
            //if(!(HttpContext.Current.Request.Url.AbsolutePath.Contains("http://localhost:4200") ||
            //    HttpContext.Current.Request.Url.AbsolutePath.Contains("http://localhost:5000")||
            //    HttpContext.Current.Request.Url.AbsolutePath.Contains("http://localhost/webapi")))
            //{
            //    HttpContext.Current.Response.AddHeader("Status Code", HttpStatusCode.Forbidden.ToString());
            //    HttpContext.Current.Response.End();
            //}
           
            
        }
    }
}
