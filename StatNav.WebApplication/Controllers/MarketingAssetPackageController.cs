using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    [Authorize]
    public class MarketingAssetPackageController : BaseController
    {
        private readonly IMAPRepository _mapRepository;

        public MarketingAssetPackageController()
            : this(new MAPRepository())
        {

        }

        public MarketingAssetPackageController(IMAPRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.StatusSortParm = sortOrder == "Status" ? "status_desc" : "Status"; //2069 - Status field removed from UI
            //ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id"; //2069 - ID field removed from UI
            List<MarketingAssetPackage> maps = _mapRepository.LoadList(sortOrder, searchString);
            ViewBag.SelectedType = "MarketingAssetPackage";
            ViewBag.SearchString = searchString;
            return View(maps);
        }

        public ActionResult Details(int id)
        {
            MarketingAssetPackage thisMap = _mapRepository.Load(id);

            if (thisMap == null)
            {
                return HttpNotFound();
            }
            return View(thisMap);
        }

        public ActionResult Create(int? packageContainerId = 0)
        {
            ViewBag.Action = "Create";
            SetDDLs();
            MarketingAssetPackage newMAP = new MarketingAssetPackage();
            if (packageContainerId != 0)
            { newMAP.PackageContainerId = packageContainerId.GetValueOrDefault(); }
            return View("Edit", newMAP);
        }

        [HttpPost]
        public ActionResult Create(MarketingAssetPackage newMAP)
        {
            string pageAction = "Create";
            try
            {
                if (ModelState.IsValid)
                {
                    _mapRepository.Add(newMAP);
                    return RedirectToAction("Edit", new { id = newMAP.Id, fromSave = "Saved" });
                }
                returnModelToEdit(pageAction, ref newMAP);
                return View("Edit", newMAP);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction, ref newMAP);
                return View("Edit", newMAP);
            }
        }

        public ActionResult Edit(int id, string fromSave)
        {
            ViewBag.Action = "Edit";
            MarketingAssetPackage thisMAP = _mapRepository.Load(id);
            if (thisMAP == null)
            {
                return HttpNotFound();
            }

            SetDDLs();
            if (fromSave == "Saved")
            { ViewBag.Notification = "Save Successful"; }
            return View("Edit", thisMAP);
        }

        [HttpPost]
        public ActionResult Edit(MarketingAssetPackage editedMAP)
        {
            string pageAction = "Edit";
            try
            {
                if (ModelState.IsValid)
                {
                    _mapRepository.Edit(editedMAP);
                    return RedirectToAction(pageAction, new { id = editedMAP.Id, fromSave = "Saved" });
                }
                returnModelToEdit(pageAction, ref editedMAP);
                return View(pageAction, editedMAP);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction, ref editedMAP);
                return View(pageAction, editedMAP);
            }
        }

        public ActionResult Delete(int id)
        {
            MarketingAssetPackage delMap = _mapRepository.Load(id);
            if (delMap == null)
            {
                return HttpNotFound();
            }

            return View(delMap);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _mapRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                MarketingAssetPackage thisMap = _mapRepository.Load(id);
                ModelState.AddModelError("", ex.Message);
                return View(thisMap);
            }
        }

        private void SetDDLs()
        {
            ViewBag.MetricModels = _mapRepository.GetMetricModels();
            ViewBag.ExperimentStatuses = _mapRepository.GetStatuses();
            ViewBag.Methods = _mapRepository.GetMethods();
            ViewBag.PackageContainers = _mapRepository.GetPCs();
        }

        private void returnModelToEdit(string action, ref MarketingAssetPackage ep)
        {
            ViewBag.Action = action;
            SetDDLs();
            if (action == "Edit")
            {
                ep.Experiments = _mapRepository.GetExperiments(ep.Id);
            }
        }
    }
}
