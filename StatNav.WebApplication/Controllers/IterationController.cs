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
    public class IterationController : BaseController
    {
        IterationLogic iLogic = new IterationLogic();

        public ActionResult Index()
        {
            List<ExperimentIteration> iterations = iLogic.LoadList();
            ViewBag.SelectedType = "Iteration";
            return View(iterations);
            
        }

        public ActionResult Details(int id)
        {
            ExperimentIteration thisIteration = iLogic.Load(id);
            if (thisIteration == null)
            {
                return HttpNotFound();
            }
            return View(thisIteration);
        }

        public ActionResult Create()
        {
            ViewBag.Action = "Create";
            ExperimentIteration newIteration = new ExperimentIteration();
            newIteration.StartDateTime = DateTime.Today;
            newIteration.EndDateTime = DateTime.Today;
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
                    iLogic.Add(newIteration);
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
            ExperimentIteration thisIteration = iLogic.Load(id);
            if (thisIteration == null)
            {
                return HttpNotFound();
            }

            SetDDLs();

            return View(thisIteration);
        }

        [HttpPost]
        public ActionResult Edit(ExperimentIteration editedIteration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    iLogic.Edit(editedIteration);
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
            ExperimentIteration delIteration = iLogic.Load(id);
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
                iLogic.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }

        private void SetDDLs()
        {
            ViewBag.ExperimentProgrammes = iLogic.GetProgrammes();
        }
    }
}
