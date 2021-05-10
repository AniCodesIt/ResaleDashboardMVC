
using ResaleDashboardMVC.Data;
using ResaleDashboardMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleDashboardMVC.Services
{
    public class SaleServices
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public List<SaleListItem> SaleIndex()
        {
            return _db.Sales.Select(e => new SaleListItem
            {
                SaleID = e.SaleID,
                PlatformID = e.PlatformID,
                InvID = e.InvID,
                SaleDate = e.SaleDate,
                SalePrice = e.SalePrice,
                Profit = e.Profit
        }).ToList();
        }
        public bool SaleCreate(SaleCreate model)
        {
            var entity =
                new Sale()
                {                
                    PlatformID = model.PlatformID,
                    InvID = model.InvID,
                    SaleDate = model.SaleDate,
                    SalePrice = model.SalePrice
                    //Profit = model.Profit                  
                };
            entity.Profit = profitFinder(entity);
            _db.Sales.Add(entity);

            return _db.SaveChanges() == 1;
        }
        public SaleEdit SaleFind(int ID)
        {
            var entity = _db.Sales.SingleOrDefault(e => e.SaleID == ID);
            var model = new SaleEdit()
            {
                SaleID = entity.SaleID,
                PlatformID = entity.PlatformID,
                InvID = entity.InvID,
                SaleDate = entity.SaleDate,
                SalePrice = entity.SalePrice,
                Profit = entity.Profit
            };           
            return model;
        }
        public SaleDetail SaleDetails(int ID)
        {
            var saleEntity = _db.Sales.SingleOrDefault(e => e.SaleID == ID);
            var saleModel = new SaleDetail()
            {
                SaleID = saleEntity.SaleID,
                PlatformID = saleEntity.PlatformID,
                InvID = saleEntity.InvID,
                SaleDate = saleEntity.SaleDate,
                SalePrice = saleEntity.SalePrice,
                Profit = saleEntity.Profit              
            };            
            return saleModel;
        }
        public bool SaleEdit(SaleEdit model)
        {
            var entity = _db.Sales.SingleOrDefault(e => e.SaleID == model.SaleID);           
            entity.PlatformID = model.PlatformID;
            entity.InvID = model.InvID;
            entity.SaleDate = model.SaleDate;
            entity.SalePrice = model.SalePrice;
            //entity.Profit = model.Profit;

            entity.Profit = profitFinder(entity);
            return _db.SaveChanges() == 1;
        }        
        
        public SaleDelete SaleDeleteFind(int ID)
        {
            var entity = _db.Sales.SingleOrDefault(e => e.SaleID == ID);
            var model = new SaleDelete()
            {
                SaleID = entity.SaleID,
                PlatformID = entity.PlatformID,
                InvID = entity.InvID,
                SaleDate = entity.SaleDate,
                SalePrice = entity.SalePrice,
                Profit = entity.Profit               
            };
            return model;
        }
        public bool SaleDelete(int ID)
        {

            var entity = _db.Sales.SingleOrDefault(e => e.SaleID == ID);
            _db.Sales.Remove(entity);
            return _db.SaveChanges() == 1;
        }
        public decimal profitFinder(Sale saleEntity)
        {
            var invEntity = _db.Inventories.SingleOrDefault(e => e.InvID == saleEntity.InvID);
            var platEntity = _db.Platforms.SingleOrDefault(e => e.PlatformID == saleEntity.PlatformID);
            //profit = sales price - fees - COG
            decimal profit = saleEntity.SalePrice - (saleEntity.SalePrice * platEntity.Fees) - invEntity.COG;
            return profit;
        }

    }

}

