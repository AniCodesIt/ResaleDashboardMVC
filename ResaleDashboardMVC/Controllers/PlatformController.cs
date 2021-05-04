using Models.PlatformModels;
using ResaleDashboardMVC.Data;
using ResaleDashboardMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResaleDashboardMVC.Controllers
{
    public class PlatformController : Controller
    {
        PlatformServices platServ = new PlatformServices();
        // GET: Platform
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            List<Platform> platList = platServ.PlatformIndex();
            return View(platList);
        }
        // Get: Platform/Create
        public ActionResult Create()
        {
            return View();
        }
        //Post: Platfrom/Create
        [HttpPost]
        public ActionResult Create(PlatformCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (platServ.PlatformCreate(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your platform could not be added. Please try again. ");
            return View(model);
        }
        // Get: PLatform/Edit{id}
        public ActionResult Edit(int id)
        {

            PlatformEdit plat = platServ.PlatformFind(id);
            if (plat == null)
            {
                return HttpNotFound();
            }
            return View(plat);
        }
        //POST: Platform/Edit{id}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Platform platform)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(platform);
        }
     
        //Get: Platform/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = platServ.PlatformFind(id);
            return View(model);
        }

        //Post: Platform/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeletePlat(int id)
        {
            platServ.PlatformDelete(id);

            //Feeling cute, might delete this later
            TempData["SaveResult"] = "Your platform was deleted";

            return RedirectToAction("Index");
        }
    }
}