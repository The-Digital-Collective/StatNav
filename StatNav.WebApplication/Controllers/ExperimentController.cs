using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    [Authorize]
    public class ExperimentController : BaseController
    {
        private readonly IExperimentRepository _eRepository;

        public ExperimentController()
            : this(new ExperimentRepository())
        {

        }

        public ExperimentController(IExperimentRepository experimentRepository)
        {
            _eRepository = experimentRepository;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";
            ViewBag.StartDateSortParm = sortOrder == "StartDate" ? "startDate_desc" : "StartDate";
            ViewBag.EndDateSortParm = sortOrder == "EndDate" ? "endDate_desc" : "EndDate";
            List<Experiment> experiments = _eRepository.LoadList(sortOrder, searchString);
            ViewBag.SelectedType = "Experiment";
            ViewBag.Sortable = true;
            return View(experiments);

        }

        public ActionResult Details(int id)
        {
            Experiment thisExperiment = _eRepository.Load(id);
            if (thisExperiment == null)
            {
                return HttpNotFound();
            }
            return View(thisExperiment);
        }

        public ActionResult Create(int? mapId = 0)
        {
            ViewBag.Action = "Create";
            Experiment newExperiment = new Experiment
            {
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today
            };
            if (mapId != null) { newExperiment.MarketingAssetPackageId = mapId.GetValueOrDefault(); }

            SetDDLs();
            return View("Edit", newExperiment);
        }

        [HttpPost]
        public ActionResult Create(Experiment newExperiment)
        {
            string pageAction = "Create";
            try
            {
                if (ModelState.IsValid)
                {
                    _eRepository.Add(newExperiment);
                    return RedirectToAction("Edit", new { id = newExperiment.Id, fromSave = "Saved" });
                }
                returnModelToEdit(pageAction, ref newExperiment);
                return View("Edit", newExperiment);                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction, ref newExperiment);
                return View("Edit", newExperiment);
            }
        }

        public ActionResult Edit(int id, string fromSave)
        {
            ViewBag.Action = "Edit";
            Experiment thisExperiment = _eRepository.Load(id);
            if (thisExperiment == null)
            {
                return HttpNotFound();
            }

            SetDDLs();
            if (fromSave == "Saved")
            { ViewBag.Notification = "Save Successful"; }
            return View("Edit", thisExperiment);
        }

        [HttpPost]
        public ActionResult Edit(Experiment editedExperiment)
        {
            string pageAction = "Edit";
            try
            {
                if (ModelState.IsValid)
                {
                    _eRepository.Edit(editedExperiment);
                    return RedirectToAction(pageAction, new { id = editedExperiment.Id, fromSave = "Saved" });
                }
                returnModelToEdit(pageAction, ref editedExperiment);
                return View(pageAction, editedExperiment);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction, ref editedExperiment);
                return View(pageAction, editedExperiment);
            }
        }

        public ActionResult Delete(int id)
        {
            Experiment delExperiment = _eRepository.Load(id);
            if (delExperiment == null)
            {
                return HttpNotFound();
            }

            return View(delExperiment);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _eRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Experiment thisExperiment = _eRepository.Load(id);
                ModelState.AddModelError("", ex.Message);
                return View(thisExperiment);
            }
        }

        private void SetDDLs()
        {
            ViewBag.MarketingAssetPackages = _eRepository.GetMAPs();
        }

        private void returnModelToEdit(string action, ref Experiment e)
        {
            ViewBag.Action = action;
            SetDDLs();
            if (action == "Edit")
            {
                e.ExperimentCandidates = _eRepository.GetCandidates(e.Id);
            }
        }
    }
}
