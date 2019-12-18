using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult Index()
        {
            //comment
            return View();
        }

       
    }
}