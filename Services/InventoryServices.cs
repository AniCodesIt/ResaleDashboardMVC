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
        public List<InventoryListItem> InventoryIndex()
        {
            return _db.Inventories.Select(e => new InventoryListItem
            {

                InvID = e.InvID,
                Brand = e.Brand,
                Category = e.Category,
                Color = e.Color,
                Size = e.Size,
                Description = e.Description,
                Source = e.Source,
                COG = e.COG,
                StockOnHand = e.StockOnHand,
                Location = e.Location


            }).ToList();           
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
           
            return _db.SaveChanges() == 1;
        }
        public InventoryEdit InventoryFind(int ID)
        {
            var entity = _db.Inventories.SingleOrDefault(e => e.InvID == ID);
            var model = new InventoryEdit()
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
            
           var entity = _db.Inventories.SingleOrDefault(e => e.InvID == model.InvID);
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
      
            var entity = _db.Inventories.SingleOrDefault(e => e.InvID == ID);
            _db.Inventories.Remove(entity);
            return _db.SaveChanges() == 1;
        }    

    }
}
