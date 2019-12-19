using System.Diagnostics;
using System.Web.Mvc;

namespace StatNav.WebApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                EventLog myLog = new EventLog("Application");
               
                myLog.WriteEntry(filterContext.RouteData.Values["controller"].ToString() + "; " + filterContext.RouteData.Values["action"].ToString() + "; " + filterContext.Exception.Message);
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult() { ViewName = "Error" };
            }
        }
    }
}