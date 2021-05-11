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

        public ActionResult VisualizeStudentResult()
        {
            return Json(Result(), JsonRequestBehavior.AllowGet);
        }

        public List<PlatformSalesListItem> Result()
        {
            SaleServices srv = new SaleServices();
            List<PlatformSalesListItem> stdResult = srv.VisualizeSales();

            //stdResult.Add(new SaleListItem()
            //{

            //    stdName = "Atir",
            //    marksObtained = 88
            //});
            //stdResult.Add(new SaleListItem()
            //{
            //    stdName = "Qasim",
            //    marksObtained = 60
            //});
            //stdResult.Add(new SaleListItem()
            //{
            //    stdName = "Hassaan Tahir",
            //    marksObtained = 77
            //});


            return stdResult;
        }
    }
}