using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    [Authorize]
    public class ProgrammeController : BaseController
    {
        // GET: Programme
        public ActionResult Index()
        {
            return View();
        }

        // GET: Programme/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Programme/Create
        public ActionResult Create()
        {
            ViewBag.Action = "Create";
            SetDDLs();
            ExperimentProgramme newProg = new ExperimentProgramme();
            return View("Edit", newProg);
        }

        // POST: Programme/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Programme/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
           ExperimentProgramme thisProg = Db.ExperimentProgrammes
                                            .Where((x=>x.Id==id))
                                            .FirstOrDefault();
            if (thisProg == null)
            {
                return HttpNotFound();
            }

            SetDDLs();
            
            return View(thisProg);
        }

        // POST: Programme/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Programme/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Programme/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void SetDDLs()
        {
            IList<MetricModel> m = Db.MetricModels
                                     .OrderBy(x => x.Title).ToList();
            ViewBag.MetricModels = m;
            IList<ExperimentStatus> s = Db.ExperimentStatuses
                                          .OrderBy(x => x.DisplayOrder).ToList();
            ViewBag.ExperimentStatuses = s;
        }
    }
}
