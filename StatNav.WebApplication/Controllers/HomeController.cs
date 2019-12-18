using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatNav.WebApplication.DAL;
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

        [Authorize]
        public ActionResult Programmes()
        {
            List < ExperimentProgramme > progs = Db.ExperimentProgrammes
                                          .OrderBy(x => x.Name)
                                          .Include(x=>x.ExperimentStatus)
                                          .OrderBy(x=>x.Id)
                                          .ToList();
            return View(progs);
        }
    }
}