using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    [Authorize]
    public class CandidateController : BaseController
    {
        private readonly ICandidateRepository _cRepository;

        public CandidateController()
            : this(new CandidateRepository())
        {

        }

        public CandidateController(ICandidateRepository candidateRepository)
        {
            _cRepository = candidateRepository;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";
            List<ExperimentCandidate> candidates = _cRepository.LoadList(sortOrder,searchString);
            ViewBag.SelectedType = "Candidate";
            ViewBag.Sortable = true;
            return View(candidates);

        }

        public ActionResult Details(int id)
        {
            ExperimentCandidate thisIteration = _cRepository.Load(id);
            if (thisIteration == null)
            {
                return HttpNotFound();
            }
            return View(thisIteration);
        }

        public ActionResult Create(int? iterationId = 0)
        {
            ViewBag.Action = "Create";
            ExperimentCandidate newCandidate = new ExperimentCandidate();
            if (iterationId != null) { newCandidate.ExperimentIterationId = iterationId.GetValueOrDefault(); }

            SetDDLs();
            return View("Edit", newCandidate);
        }

        [HttpPost]
        public ActionResult Create(ExperimentCandidate newCandidate)
        {
            string pageAction = "Create";
            try
            {
                if (ModelState.IsValid)
                {
                    _cRepository.Add(newCandidate);
                    return RedirectToAction("Edit", new { id = newCandidate.Id, fromSave = "Saved" });
                }
                returnModelToEdit(pageAction);
                return View("Edit", newCandidate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction);
                return View("Edit", newCandidate);
            }
        }

        public ActionResult Edit(int id, string fromSave)
        {
            ViewBag.Action = "Edit";
            ExperimentCandidate thisCandidate = _cRepository.Load(id);
            if (thisCandidate == null)
            {
                return HttpNotFound();
            }

            SetDDLs();
            if (fromSave == "Saved")
            { ViewBag.Notification = "Save Successful"; }
            return View("Edit", thisCandidate);
        }

        [HttpPost]
        public ActionResult Edit(ExperimentCandidate editedCandidate)
        {
            string pageAction = "Edit";
            try
            {
                if (ModelState.IsValid)
                {
                    _cRepository.Edit(editedCandidate);
                    return RedirectToAction(pageAction, new { id = editedCandidate.Id, fromSave = "Saved" });
                }
                returnModelToEdit(pageAction);
                return View(pageAction, editedCandidate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction);
                return View(pageAction, editedCandidate);
            }
        }

        public ActionResult Delete(int id)
        {
            ExperimentCandidate delCandidate = _cRepository.Load(id);
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
                _cRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ExperimentCandidate thisCandidate = _cRepository.Load(id);
                ModelState.AddModelError("", ex.Message);
                return View(thisCandidate);
            }
        }

        private void SetDDLs()
        {
            ViewBag.MetricModels = _cRepository.GetMetricModels();
            ViewBag.ExperimentIterations = _cRepository.GetIterations();
        }

        private void returnModelToEdit(string action)
        {
            ViewBag.Action = action;
            SetDDLs();           
        }
    }
}
