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

                 
                    PlatformID = model
                  
                };
            _db.Sales.Add(entity);

            return _db.SaveChanges() == 1;
        }
        public SaleEdit SaleFind(int ID)
        {
            var entity = _db.Sales.SingleOrDefault(e => e.InvID == ID);
            var model = new SaleEdit()
            {
                InvID = entity.InvID,
                Brand = entity.Brand,
                Category = entity.Category,
                Color = entity.Color,
                Size = entity.Size,
                Description = entity.Description,
                Source = entity.Source,
                COG = entity.COG,
                StockOnHand = entity.StockOnHand,
                Location = entity.Location
            };
            return model;
        }
        public bool InventoryEdit(InventoryEdit model)
        {

            var entity = _db.Sales.SingleOrDefault(e => e.InvID == model.InvID);
            entity.Brand = model.Brand;
            entity.Category = model.Category;
            entity.Color = model.Color;
            entity.Size = model.Size;
            entity.Description = model.Description;
            entity.Source = model.Source;
            entity.COG = model.COG;
            entity.StockOnHand = model.StockOnHand;
            entity.Location = model.Location;


            return _db.SaveChanges() == 1;
        }
        public bool InventoryDelete(int ID)
        {

            var entity = _db.Sales.SingleOrDefault(e => e.InvID == ID);
            _db.Sales.Remove(entity);
            return _db.SaveChanges() == 1;
        }

    }
}
