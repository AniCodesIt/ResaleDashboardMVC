using ResaleDashboardMVC.Models.PlatformModels;
using ResaleDashboardMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResaleDashboardMVC.Data;

namespace ResaleDashboardMVC.Services
{
    public class PlatformServices
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public List<Platform> PlatformIndex()
        {
            return _db.Platforms.ToList();
        }
        public bool PlatformCreate(PlatformCreate model)
        {
            var entity =
                new Platform()
                {                  
                    PlatformName = model.PlatformName,
                    Fees = model.Fees                   
                };
            _db.Platforms.Add(entity);

            return _db.SaveChanges() == 1;
        }
        public PlatformEdit PlatformFind(int ID)
        {
            var entity = _db.Platforms.SingleOrDefault(e => e.PlatformID == ID);
            var model = new PlatformEdit()
            {
                PlatformID = entity.PlatformID,
                PlatformName = entity.PlatformName,
                Fees = entity.Fees               
            };
            return model;
        }
        public bool PlatformEdit(PlatformEdit model)
        {
            var entity = _db.Platforms.SingleOrDefault(e => e.PlatformID == model.PlatformID);
            entity.PlatformID = model.PlatformID;
            entity.PlatformName = model.PlatformName;
            entity.Fees = model.Fees;       

            return _db.SaveChanges() == 1;
        }
        public bool PlatformDelete(int ID)
        {

            var entity = _db.Platforms.SingleOrDefault(e => e.PlatformID == ID);
            _db.Platforms.Remove(entity);
            return _db.SaveChanges() == 1;
        }

    }
}
