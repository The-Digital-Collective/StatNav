using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StatNav.WebApplication.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        //empty placeholder controller for the moment - for demo in Feb 2020
        public ActionResult Index()
        {
            return View();
        }
    }
}