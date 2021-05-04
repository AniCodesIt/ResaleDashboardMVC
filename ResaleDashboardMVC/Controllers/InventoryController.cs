using ResaleDashboardMVC.Data;
using ResaleDashboardMVC.Models;
using ResaleDashboardMVC.Services;
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
        public ActionResult Create(InventoryCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (invServ.InventoryCreate(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your inventory item could not be added. Please try again. ");
            return View(model);
        }
        // Get: Inventory/Edit{id}
        public ActionResult Edit(int id)
        {
            
          InventoryEdit inv = invServ.InventoryFind(id);
            if (inv == null)
            {
                return HttpNotFound();
            }
            return View(inv);
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
        //// Post: Inventory/Delete{id}
        //[HttpPost, ActionName("Delete")]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    bool delete  = invServ.InventoryDelete(id);
        //    if(delete == true)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    ModelState.AddModelError("", "Your inventory item was not deleted. Please try again. ");
        //    return View(id);

        //}
        //Get: Inventory/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {            
            var model = invServ.InventoryFind(id);
            return View(model);
        }

        //Post: Inventory/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteInv(int id)
        {        

            invServ.InventoryDelete(id);

            //Feeling cute, might delete this later
            TempData["SaveResult"] = "Your inventory item was deleted";

            return RedirectToAction("Index");
        }       
    }
}
