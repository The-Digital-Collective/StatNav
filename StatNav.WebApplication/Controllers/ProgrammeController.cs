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
        private readonly IProgrammeRepository _pRepository;

        public ProgrammeController()
            : this(new ProgrammeRepository())
        {

        }

        public ProgrammeController(IProgrammeRepository programmeRepository)
        {
            _pRepository = programmeRepository;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "status_desc" : "Status";
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";
            List<ExperimentProgramme> progs = _pRepository.LoadList(sortOrder, searchString);
            ViewBag.SelectedType = "Programme";
            return View(progs);
        }

        public ActionResult Details(int id)
        {
            ExperimentProgramme thisProg = _pRepository.Load(id);

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
            string pageAction = "Create";
            try
            {
                if (ModelState.IsValid)
                {
                    _pRepository.Add(newProg);
                    return RedirectToAction("Edit", new { id = newProg.Id });
                }
                returnModelToEdit(pageAction, ref newProg);
                return View("Edit", newProg);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction, ref newProg);
                return View("Edit", newProg);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ExperimentProgramme thisProg = _pRepository.Load(id);
            if (thisProg == null)
            {
                return HttpNotFound();
            }

            SetDDLs();

            return View("Edit", thisProg);
        }

        [HttpPost]
        public ActionResult Edit(ExperimentProgramme editedProg)
        {
            string pageAction = "Edit";
            try
            {
                if (ModelState.IsValid)
                {
                    _pRepository.Edit(editedProg);
                    return RedirectToAction(pageAction, new { id = editedProg.Id });
                }
                returnModelToEdit(pageAction, ref editedProg);
                return View(pageAction, editedProg);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction, ref editedProg);
                return View(pageAction, editedProg);
            }
        }

        public ActionResult Delete(int id)
        {
            ExperimentProgramme delProg = _pRepository.Load(id);
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
                _pRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ExperimentProgramme thisProg = _pRepository.Load(id);
                ModelState.AddModelError("", ex.Message);
                return View(thisProg);
            }
        }

        private void SetDDLs()
        {
            ViewBag.MetricModels = _pRepository.GetMetricModels();
            ViewBag.ExperimentStatuses = _pRepository.GetStatuses();
            ViewBag.Methods = _pRepository.GetMethods();
        }

        private void returnModelToEdit(string action, ref ExperimentProgramme ep)
        {
            ViewBag.Action = action;
            SetDDLs();
            if (action == "Edit")
            {
                ep.ExperimentIterations = _pRepository.GetIterations(ep.Id);
            }
        }
    }
}
