using System.Diagnostics;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;

namespace StatNav.WebApplication.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                if (filterContext.HttpContext != null && filterContext.Exception != null)
                {
                    if (filterContext.HttpContext.IsCustomErrorEnabled)
                    {
                        var ai = new TelemetryClient();
                        ai.TrackException(filterContext.Exception);
                    }
                }
            }
        }
    }
}