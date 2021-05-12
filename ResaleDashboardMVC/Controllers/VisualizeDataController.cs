using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResaleDashboardMVC.Models;
using Newtonsoft.Json;
using ResaleDashboardMVC.Services;

namespace ResaleDashboardMVC.Controllers
{
    public class VisualizeDataController : Controller
    {

        public ActionResult ColumnChart()
        {
            return View();
        }

        public ActionResult PieChart()
        {
            return View();
        }

        public ActionResult LineChart()
        {
            return View();
        }

        public ActionResult VisualizeResult()
        {
            return Json(Result(), JsonRequestBehavior.AllowGet);
        }

        public List<PlatformSalesListItem> Result()
        {
            SaleServices srv = new SaleServices();
            List<PlatformSalesListItem> stdResult = srv.VisualizeSales();

            //stdResult.Add(new SaleListItem()
            //{

            //    stdName = "Poshmark",
            //    percentage = 35
            //});
            //stdResult.Add(new SaleListItem()
            //{
            //    stdName = "Ebay",
            //    percentage = 30
            //});  //stdResult.Add(new SaleListItem()
            //{
            //    stdName = "Mercari",
            //    percentage = 20
            //});
            //stdResult.Add(new SaleListItem()
            //{
            //    stdName = "Tradesy",
            //    percentage = 15
            //});


            return stdResult;
        }
    }
}