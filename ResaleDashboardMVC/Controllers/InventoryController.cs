using ResaleDashboardMVC.Data;
using ResaleDashboardMVC.Models;
using ResaleDashboardMVC.Services;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Create(InventoryCreate model)
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
    }
}