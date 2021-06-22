using ResaleDashboardMVC.Models;
using ResaleDashboardMVC.Data;
using ResaleDashboardMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResaleDashboardMVC.Controllers
{
    public class SaleController : Controller
    {
        SaleServices saleServ = new SaleServices();
        PlatformServices platServ = new PlatformServices();
        // GET: Sale
        [HttpGet]
        ////[ValidateAntiForgeryToken]
      
        public ActionResult Index()
        {
            List<SaleListItem> saleList = saleServ.SaleIndex();
            return View(saleList);
        }
        // Get: Sale/Create
        public ActionResult Create()
        {
            List<PlatformListItem> listOfPlatforms = platServ.PlatformIndex();
            
            return View(listOfPlatforms);
        }
        //Post: Sale/Create
        [HttpPost]
        public ActionResult Create(SaleCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (saleServ.SaleCreate(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your platform could not be added. Please try again. ");
            return View(model);
        }
        // Get: Sale/Edit{id}
        public ActionResult Edit(int id)
        {

            SaleEdit sale = saleServ.SaleFind(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }
        //POST: Sale/Edit{id}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(SaleEdit model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if (saleServ.SaleEdit(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Sale could not be edited");
            return View(model);
        }
        //Get:Sale/Details/{id}
        [ActionName("Details")]
        public ActionResult Find(int id)
        {
            var model = saleServ.SaleDetails(id);
            return View(model);
        }
            //Get: Sale/Delete/{id}
            [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = saleServ.SaleDeleteFind(id);
            return View(model);
        }

        //Post: Sale/Delete/{id}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ActionName("Delete")]      
        public ActionResult DeleteSale(int id)
        {
            saleServ.SaleDelete(id);

            //Feeling cute, might delete this later
            TempData["SaveResult"] = "Your sale was deleted ";

            return RedirectToAction("Index");
        }
    }
}