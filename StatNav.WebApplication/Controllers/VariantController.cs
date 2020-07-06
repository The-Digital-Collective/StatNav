using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    [Authorize]
    public class VariantController : BaseController
    {
        private readonly IVariantRepository _vRepository;

        public VariantController()
            : this(new VariantRepository())
        {

        }

        public VariantController(IVariantRepository variantRepository)
        {
            _vRepository = variantRepository;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";
            List<Variant> variants = _vRepository.LoadList(sortOrder,searchString);
            ViewBag.SelectedType = "Variant";
            ViewBag.Sortable = true;
            ViewBag.SearchString = searchString;
            return View(variants);

        }

        public ActionResult Details(int id)
        {
            Variant thisVariant= _vRepository.Load(id);
            if (thisVariant == null)
            {
                return HttpNotFound();
            }
            return View(thisVariant);
        }

        public ActionResult Create(int? experimentId = 0)
        {
            ViewBag.Action = "Create";
            Variant newVariant = new Variant();
            if (experimentId != null) { newVariant.ExperimentId = experimentId.GetValueOrDefault(); }

            SetDDLs();
            return View("Edit", newVariant);
        }

        [HttpPost]
        public ActionResult Create(Variant newVariant)
        {
            string pageAction = "Create";
            try
            {
                if (ModelState.IsValid)
                {
                    _vRepository.Add(newVariant);
                    return RedirectToAction("Edit", new { id = newVariant.Id, fromSave = "Saved" });
                }
                returnModelToEdit(pageAction);
                return View("Edit", newVariant);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction);
                return View("Edit", newVariant);
            }
        }

        public ActionResult Edit(int id, string fromSave)
        {
            ViewBag.Action = "Edit";
            Variant thisVariant = _vRepository.Load(id);
            if (thisVariant == null)
            {
                return HttpNotFound();
            }

            SetDDLs();
            if (fromSave == "Saved")
            { ViewBag.Notification = "Save Successful"; }
            return View("Edit", thisVariant);
        }

        [HttpPost]
        public ActionResult Edit(Variant editedVariant)
        {
            string pageAction = "Edit";
            try
            {
                if (ModelState.IsValid)
                {
                    _vRepository.Edit(editedVariant);
                    return RedirectToAction(pageAction, new { id = editedVariant.Id, fromSave = "Saved" });
                }
                returnModelToEdit(pageAction);
                return View(pageAction, editedVariant);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction);
                return View(pageAction, editedVariant);
            }
        }

        public ActionResult Delete(int id)
        {
            Variant delVariant = _vRepository.Load(id);
            if (delVariant == null)
            {
                return HttpNotFound();
            }

            return View(delVariant);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _vRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Variant thisVariant = _vRepository.Load(id);
                ModelState.AddModelError("", ex.Message);
                return View(thisVariant);
            }
        }

        private void SetDDLs()
        {
            ViewBag.MetricModels = _vRepository.GetMetricModels();
            ViewBag.Experiments = _vRepository.GetExperiments();
        }

        private void returnModelToEdit(string action)
        {
            ViewBag.Action = action;
            SetDDLs();           
        }
    }
}
