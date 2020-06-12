using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Controllers
{
    // TODO
    //[Authorize]
    public class PackageContainerController : BaseController
    {
        private readonly IPackageContainerRepository _pcRepository;

        public PackageContainerController()
            : this(new PackageContainerRepository())
        {

        }

        public PackageContainerController(IPackageContainerRepository containerRepository)
        {
            _pcRepository = containerRepository;
        }

        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.StatusSortParm = sortOrder == "Status" ? "status_desc" : "Status";
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";
            List<PackageContainer> containers = _pcRepository.LoadList(sortOrder, searchString);
            ViewBag.SelectedType = "PackageContainer";
            return View(containers);
        }

        public ActionResult Details(int id)
        {
            PackageContainer thisContainer = _pcRepository.Load(id);

            if (thisContainer == null)
            {
                return HttpNotFound();
            }
            return View(thisContainer);
        }

        public ActionResult Create()
        {
            ViewBag.Action = "Create";
            SetDDLs();
            PackageContainer newContainer = new PackageContainer();
            return View("Edit", newContainer);
        }

        [HttpPost]
        public ActionResult Create(PackageContainer newContainer)
        {
            string pageAction = "Create";
            try
            {
                if (ModelState.IsValid)
                {
                    _pcRepository.Add(newContainer);
                    return RedirectToAction("Edit", new { id = newContainer.Id });
                }
                returnModelToEdit(pageAction, ref newContainer);
                return View("Edit", newContainer);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction, ref newContainer);
                return View("Edit", newContainer);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            PackageContainer thisContainer = _pcRepository.Load(id);
            if (thisContainer == null)
            {
                return HttpNotFound();
            }

            SetDDLs();

            return View("Edit", thisContainer);
        }

        [HttpPost]
        public ActionResult Edit(PackageContainer editedContainer)
        {
            string pageAction = "Edit";
            try
            {
                if (ModelState.IsValid)
                {
                    _pcRepository.Edit(editedContainer);
                    return RedirectToAction(pageAction, new { id = editedContainer.Id });
                }
                returnModelToEdit(pageAction, ref editedContainer);
                return View(pageAction, editedContainer);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                returnModelToEdit(pageAction, ref editedContainer);
                return View(pageAction, editedContainer);
            }
        }

        public ActionResult Delete(int id)
        {
            PackageContainer delContainer = _pcRepository.Load(id);
            if (delContainer == null)
            {
                return HttpNotFound();
            }

            return View(delContainer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _pcRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                PackageContainer thisContainer = _pcRepository.Load(id);
                ModelState.AddModelError("", ex.Message);
                return View(thisContainer);
            }
        }

        private void SetDDLs()
        {
            ViewBag.Stages = _pcRepository.GetStages();          
        }

        private void returnModelToEdit(string action, ref PackageContainer pc)
        {
            ViewBag.Action = action;
            SetDDLs();
            if (action == "Edit")
            {
                pc.ExperimentProgrammes = _pcRepository.GetProgrammes(pc.Id);
            }
        }
    }
}
