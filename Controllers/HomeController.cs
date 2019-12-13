using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatNav.DAL;
using StatNav.Models;

namespace StatNav.Controllers
{
    public class HomeController : Controller
    {
        private StatNavContext _db = new StatNavContext();
        public ActionResult Index()
        {
            //comment
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Programmes()
        {
            List < Programme > progs = _db.Programmes
                                          .OrderBy(x => x.Name)
                                          .Include(x=>x.Status)
                                          .ToList();
            return View(progs);
        }
    }
}