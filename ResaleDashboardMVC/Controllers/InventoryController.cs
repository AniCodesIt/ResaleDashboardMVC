using ResaleDashboardMVC.Data;
using ResaleDashboardMVC.Models;
using ResaleDashboardMVC.Services;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ResaleDashboardMVC.Controllers
{
    public class InventoryController : Controller
    {
        InventoryServices invServ = new InventoryServices();
        // GET: Inventory
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            List<Inventory> invList = invServ.InventoryIndex();
            return View(invList);
        }
        // Get: Inventory/Create
        public ActionResult Create()
        {
            return View();         
        }
        //Post: Category/Create
        [HttpPost]
        public ActionResult Create(SaleCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (invServ.InventoryCreate(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Inventory could not be added. Please try again.");
            return View(model);
        }
        // Get: Inventory/Edit{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
          
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }
        //POST: Inventory/Edit{id}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(inventory);
        }
    }
}