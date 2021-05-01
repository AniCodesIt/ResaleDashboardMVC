using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResaleDashboardMVC.Models;
using ResaleDashboardMVC.Data;

namespace ResaleDashboardMVC.Services
{
    public class InventoryServices
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public List<Inventory> InventoryIndex()
        {
            return _db.Inventories.ToList();
        }
        public bool InventoryCreate(InventoryCreate model)
        {
            var entity =
                new Inventory()
                {

                    Brand = model.Brand,
                    Category = model.Category,
                    Color = model.Color,
                    Size = model.Size,
                    Description = model.Description,
                    Source = model.Source,
                    COG = model.COG,
                    StockOnHand = model.StockOnHand,
                    Location = model.Location
                };
            _db.Inventories.Add(entity); 

            if(_db.SaveChanges() == 1)
            {

            }
            return _db.SaveChanges() == 1;
        }
    }
}
