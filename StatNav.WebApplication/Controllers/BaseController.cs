using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatNav.WebApplication.DAL;

namespace StatNav.WebApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly StatNavContext Db = new StatNavContext();
        protected override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                EventLog myLog = new EventLog("Application");
               
                myLog.WriteEntry(context.RouteData.Values["controller"].ToString() + "; " + context.RouteData.Values["action"].ToString() + "; " + context.Exception.Message);
                context.ExceptionHandled = true;
                context.Result = new ViewResult() { ViewName = "Error" };
            }
        }
    }
}