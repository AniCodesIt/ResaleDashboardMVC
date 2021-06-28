
using ResaleDashboardMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResaleDashboardMVC.Data;
using System.Web.Mvc;

namespace ResaleDashboardMVC.Services
{
    public class PlatformServices
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public List<PlatformListItem> PlatformIndex()
        {
            return _db.Platforms.Select(e => new PlatformListItem
            {
                PlatformID = e.PlatformID,
                PlatformName = e.PlatformName,
                Fees = e.Fees


            }).ToList();
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
        public PlatformDetail PlatformDetails(int ID)
        {
            var entity = _db.Platforms.SingleOrDefault(e => e.PlatformID == ID);
            var model = new PlatformDetail()
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
        public PlatformDelete PlatformDeleteFind(int ID)
        {
            var entity = _db.Platforms.SingleOrDefault(e => e.PlatformID == ID);
            var model = new PlatformDelete()
            {
                PlatformID = entity.PlatformID,
                PlatformName = entity.PlatformName,
                Fees = entity.Fees,
             
            };
            return model;
        }
        public bool PlatformDelete(int ID)
        {

            var entity = _db.Platforms.SingleOrDefault(e => e.PlatformID == ID);
            _db.Platforms.Remove(entity);
            return _db.SaveChanges() == 1;
        }
        //Creates the data for the dropdown ilst
        public List<SelectListItem> PlatformListDropdownData()
        {
            //call the index
            List<PlatformListItem> platformDropdownData = PlatformIndex();

            //New up a list
            List<SelectListItem> dataHolder = new List<SelectListItem>();           

            //fill list with select list items from index
            foreach(var item in platformDropdownData)
            {
                //New it up
                SelectListItem platformDropdown = new SelectListItem();
                //push date
                platformDropdown.Text = item.PlatformName;
                platformDropdown.Value = item.PlatformID.ToString();
                //add to the new list
                dataHolder.Add(platformDropdown);
            }
            return dataHolder;

        }




    }
}
