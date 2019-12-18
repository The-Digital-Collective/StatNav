using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    [Authorize]
    public class ProgrammeController : BaseController
    {
        [Authorize]
        // GET: Programme
        public ActionResult Index()
        {
            List<ExperimentProgramme> progs = Db.ExperimentProgrammes
                .OrderBy(x => x.Name)
                .Include(x => x.ExperimentStatus)
                .ToList();
            ViewBag.SelectedType = "Programme";
            return View(progs);
        }

        // GET: Programme/Details/5
        public ActionResult Details(int id)
        {
            ExperimentProgramme thisProg = Db.ExperimentProgrammes
                .Where((x => x.Id == id))
                .FirstOrDefault();
            if (thisProg == null)
            {
                return HttpNotFound();
            }


            return View(thisProg);
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
        public ActionResult Create(ExperimentProgramme newProg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Db.ExperimentProgrammes.Add(newProg);
                    Db.SaveChanges();
                    return RedirectToAction("Programmes", "Home");
                }
                ViewBag.Action = "Create";
                SetDDLs();
                return View("Edit", newProg);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Action = "Create";
                SetDDLs();
                return View(newProg);
            }
        }

        // GET: Programme/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ExperimentProgramme thisProg = Db.ExperimentProgrammes
                                             .Where((x => x.Id == id))
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
        public ActionResult Edit(ExperimentProgramme editedProg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Db.Entry(editedProg).State = EntityState.Modified;
                    Db.SaveChanges();
                    return RedirectToAction("Programmes", "Home");
                }
                ViewBag.Action = "Edit";
                SetDDLs();
                return View("Edit", editedProg);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Action = "Edit";
                SetDDLs();
                return View("Edit", editedProg);
            }
        }

        // GET: Programme/Delete/5
        public ActionResult Delete(int id)
        {
            ExperimentProgramme delProg = Db.ExperimentProgrammes
                .Where((x => x.Id == id))
                .FirstOrDefault();
            if (delProg == null)
            {
                return HttpNotFound();
            }

            return View(delProg);
        }

        // POST: Programme/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var progToDel = Db.ExperimentProgrammes
                                  .Include(x => x.ExperimentIterations)
                                  .FirstOrDefault(x => x.Id == id);
                progToDel?.ExperimentIterations.ToList().ForEach(n => Db.ExperimentIterations.Remove(n));
                Db.ExperimentProgrammes.Remove(progToDel);
                Db.SaveChanges();
                return RedirectToAction("Programmes","Home");
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
