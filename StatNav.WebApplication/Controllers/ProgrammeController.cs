using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    [Authorize]
    public class ProgrammeController : BaseController
    {
        ProgrammeLogic pLogic = new ProgrammeLogic();
        // GET: Programme
        public ActionResult Index()
        {
            List<ExperimentProgramme> progs = pLogic.LoadList();
            ViewBag.SelectedType = "Programme";
            return View(progs);
        }

        // GET: Programme/Details/5
        public ActionResult Details(int id)
        {
            ExperimentProgramme thisProg = pLogic.Load(id);

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
                    pLogic.Add(newProg);
                    return RedirectToAction("Index");
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
            ExperimentProgramme thisProg = pLogic.Load(id);
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
                    pLogic.Edit(editedProg);
                    return RedirectToAction("Index");
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
            ExperimentProgramme delProg = pLogic.Load(id);
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
                pLogic.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void SetDDLs()
        {
            ViewBag.MetricModels = pLogic.GetMetricModels(); 
            ViewBag.ExperimentStatuses = pLogic.GetStatuses();
        }
    }
}
