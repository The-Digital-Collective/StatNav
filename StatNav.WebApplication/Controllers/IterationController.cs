using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    [Authorize]
    public class IterationController : BaseController
    {
        private readonly IIterationRepository _iRepository;

        public IterationController()
            : this(new IterationRepository())
        {

        }

        public IterationController(IIterationRepository iterationRepository)
        {
            _iRepository = iterationRepository;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";
            ViewBag.StartDateSortParm = sortOrder == "StartDate" ? "startDate_desc" : "StartDate";
            ViewBag.EndDateSortParm = sortOrder == "EndDate" ? "endDate_desc" : "EndDate";
            List<ExperimentIteration> iterations = _iRepository.LoadList(sortOrder, searchString);
            ViewBag.SelectedType = "Iteration";
            ViewBag.Sortable = true;
            return View(iterations);

        }

        public ActionResult Details(int id)
        {
            ExperimentIteration thisIteration = _iRepository.Load(id);
            if (thisIteration == null)
            {
                return HttpNotFound();
            }
            return View(thisIteration);
        }

        public ActionResult Create(int? programmeId = 0)
        {
            ViewBag.Action = "Create";
            ExperimentIteration newIteration = new ExperimentIteration
            {
                StartDateTime = DateTime.Today,
                EndDateTime = DateTime.Today
            };
            if (programmeId != null) { newIteration.ExperimentProgrammeId = programmeId.GetValueOrDefault(); }

            SetDDLs();
            return View("Edit", newIteration);
        }

        [HttpPost]
        public ActionResult Create(ExperimentIteration newIteration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iRepository.Add(newIteration);
                    return RedirectToAction("Index");
                }
                ViewBag.Action = "Create";
                SetDDLs();
                return View("Edit", newIteration);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Action = "Create";
                SetDDLs();
                return View("Edit", newIteration);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ExperimentIteration thisIteration = _iRepository.Load(id);
            if (thisIteration == null)
            {
                return HttpNotFound();
            }

            SetDDLs();

            return View("Edit", thisIteration);
        }

        [HttpPost]
        public ActionResult Edit(ExperimentIteration editedIteration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iRepository.Edit(editedIteration);
                    return RedirectToAction("Index");
                }
                ViewBag.Action = "Edit";
                SetDDLs();
                return View("Edit", editedIteration);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Action = "Edit";
                SetDDLs();
                return View("Edit", editedIteration);
            }
        }

        public ActionResult Delete(int id)
        {
            ExperimentIteration delIteration = _iRepository.Load(id);
            if (delIteration == null)
            {
                return HttpNotFound();
            }

            return View(delIteration);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _iRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ExperimentIteration thisIteration = _iRepository.Load(id);
                ModelState.AddModelError("", ex.Message);
                return View(thisIteration);
            }
        }

        private void SetDDLs()
        {
            ViewBag.ExperimentProgrammes = _iRepository.GetProgrammes();
        }
    }
}
