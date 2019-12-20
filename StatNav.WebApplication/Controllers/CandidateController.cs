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
    public class CandidateController : BaseController
    {
        private readonly CandidateLogic _cLogic = new CandidateLogic();

        public ActionResult Index()
        {
            List<ExperimentCandidate> candidates = _cLogic.LoadList();
            ViewBag.SelectedType = "Candidate";
            return View(candidates);
            
        }

        public ActionResult Details(int id)
        {
            ExperimentCandidate thisIteration = _cLogic.Load(id);
            if (thisIteration == null)
            {
                return HttpNotFound();
            }
            return View(thisIteration);
        }

        public ActionResult Create()
        {
            ViewBag.Action = "Create";
            ExperimentCandidate newCandidate = new ExperimentCandidate();
           
            SetDDLs();
            return View("Edit", newCandidate);
        }

        [HttpPost]
        public ActionResult Create(ExperimentCandidate newCandidate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cLogic.Add(newCandidate);
                    return RedirectToAction("Index");
                }
                ViewBag.Action = "Create";
                SetDDLs();
                return View("Edit", newCandidate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Action = "Create";
                SetDDLs();
                return View("Edit", newCandidate);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ExperimentCandidate thisCandidate = _cLogic.Load(id);
            if (thisCandidate == null)
            {
                return HttpNotFound();
            }

            SetDDLs();

            return View(thisCandidate);
        }

        [HttpPost]
        public ActionResult Edit(ExperimentCandidate editedCandidate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cLogic.Edit(editedCandidate);
                    return RedirectToAction("Index");
                }
                ViewBag.Action = "Edit";
                SetDDLs();
                return View("Edit", editedCandidate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Action = "Edit";
                SetDDLs();
                return View("Edit", editedCandidate);
            }
        }

        public ActionResult Delete(int id)
        {
            ExperimentCandidate delCandidate = _cLogic.Load(id);
            if (delCandidate == null)
            {
                return HttpNotFound();
            }

            return View(delCandidate);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _cLogic.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ExperimentCandidate thisCandidate = _cLogic.Load(id);
                ModelState.AddModelError("", ex.Message);
                return View(thisCandidate);
            }
        }

        private void SetDDLs()
        {
            ProgrammeLogic pLogic = new ProgrammeLogic();
            ViewBag.MetricModels = pLogic.GetMetricModels();
            ViewBag.ExperimentIterations = _cLogic.GetIterations();
        }
    }
}
