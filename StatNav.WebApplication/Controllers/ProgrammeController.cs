using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    [Authorize]
    public class ProgrammeController : BaseController
    {
        private readonly IProgrammeRepository _pLogic;

        public ProgrammeController()
            : this( new ProgrammeLogic())
        {
            
        }

        public ProgrammeController(IProgrammeRepository programmeRepository)
        {
            _pLogic = programmeRepository;
        }

        public ActionResult Index()
        {
            List<ExperimentProgramme> progs = _pLogic.LoadList();
            ViewBag.SelectedType = "Programme";
            return View(progs);
        }

        public ActionResult Details(int id)
        {
            ExperimentProgramme thisProg = _pLogic.Load(id);

            if (thisProg == null)
            {
                return HttpNotFound();
            }
            return View(thisProg);
        }

        public ActionResult Create()
        {
            ViewBag.Action = "Create";
            SetDDLs();
            ExperimentProgramme newProg = new ExperimentProgramme();
            return View("Edit", newProg);
        }

        [HttpPost]
        public ActionResult Create(ExperimentProgramme newProg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pLogic.Add(newProg);
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
                return View("Edit", newProg);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ExperimentProgramme thisProg = _pLogic.Load(id);
            if (thisProg == null)
            {
                return HttpNotFound();
            }

            SetDDLs();

            return View(thisProg);
        }

        [HttpPost]
        public ActionResult Edit(ExperimentProgramme editedProg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pLogic.Edit(editedProg);
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

        public ActionResult Delete(int id)
        {
            ExperimentProgramme delProg = _pLogic.Load(id);
            if (delProg == null)
            {
                return HttpNotFound();
            }

            return View(delProg);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _pLogic.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ExperimentProgramme thisProg = _pLogic.Load(id);
                ModelState.AddModelError("", ex.Message);
                return View(thisProg);
            }
        }

        private void SetDDLs()
        {
            ViewBag.MetricModels = _pLogic.GetMetricModels(); 
            ViewBag.ExperimentStatuses = _pLogic.GetStatuses();
        }
    }
}
