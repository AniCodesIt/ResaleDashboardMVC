using Models.SaleModels;
using ResaleDashboardMVC.Data;
using ResaleDashboardMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SaleServices
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public List<Sale> SaleIndex()
        {
            return _db.Sales.ToList();
        }
        public bool SaleCreate(SaleCreate model)
        {
            var entity =
                new Sale()
                {                
                    PlatformID = model.PlatformID,
                    InvID = model.InvID,
                    SaleDate = model.SaleDate,
                    SalePrice = model.SalePrice,
                    Profit = model.Profit                  
                };
            _db.Sales.Add(entity);

            return _db.SaveChanges() == 1;
        }
        public SaleEdit SaleFind(int ID)
        {
            var entity = _db.Sales.SingleOrDefault(e => e.SaleID == ID);
            var model = new SaleEdit()
            {
                PlatformID = entity.PlatformID,
                InvID = entity.InvID,
                SaleDate = entity.SaleDate,
                SalePrice = entity.SalePrice,
                Profit = entity.Profit
            };
            return model;
        }
        public bool SaleEdit(SaleEdit model)
        {
            var entity = _db.Sales.SingleOrDefault(e => e.SaleID == model.SaleID);           
            entity.PlatformID = model.PlatformID;
            entity.InvID = model.InvID;
            entity.SaleDate = model.SaleDate;
            entity.SalePrice = model.SalePrice;
            entity.Profit = model.Profit;

            return _db.SaveChanges() == 1;
        }
        public bool SaleDelete(int ID)
        {

            var entity = _db.Sales.SingleOrDefault(e => e.SaleID == ID);
            _db.Sales.Remove(entity);
            return _db.SaveChanges() == 1;
        }

    }
}
