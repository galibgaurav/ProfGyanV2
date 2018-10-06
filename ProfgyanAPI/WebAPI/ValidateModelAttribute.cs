using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI
{
    //This is replacement for ModelState.IsValid , it validate the client data before it hits the controller
    //currently I am not using
    //public class ValidateModelAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(HttpActionContext actionContext)
    //    {
    //        if(actionContext.ModelState.IsValid==false)
    //        {
    //            actionContext.Response = actionContext.Request.CreateErrorResponse(
    //              HttpStatusCode.BadRequest, actionContext.ModelState);
    //        }
           
    //    }
    //}
}