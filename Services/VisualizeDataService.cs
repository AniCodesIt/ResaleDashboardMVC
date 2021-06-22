
using Models.VisualizeDataModels;
using ResaleDashboardMVC.Data;
using ResaleDashboardMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ResaleDashboardMVC.Services
{
    public class VisualizeDataService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        SaleServices saleServ = new SaleServices();
        
       
        
        public decimal profitFinder(SaleListItem saleEntity)
        {
            var invEntity = _db.Inventories.SingleOrDefault(e => e.InvID == saleEntity.InvID);
            var platEntity = _db.Platforms.SingleOrDefault(e => e.PlatformID == saleEntity.PlatformID);
            //profit = sales price - fees - COG
            decimal profit = saleEntity.SalePrice - (saleEntity.SalePrice * platEntity.Fees) - invEntity.COG;
            return profit;
        }
        //keep
        public decimal profitFinder(Sale saleEntity)
        {
            var invEntity = _db.Inventories.SingleOrDefault(e => e.InvID == saleEntity.InvID);
            var platEntity = _db.Platforms.SingleOrDefault(e => e.PlatformID == saleEntity.PlatformID);
            //profit = sales price - fees - COG
            decimal profit = saleEntity.SalePrice - (saleEntity.SalePrice * platEntity.Fees) - invEntity.COG;
            return profit;
        }
        //keep
        public string categoryFinder(SaleListItem saleEntity)
        {
            var invEntity = _db.Inventories.SingleOrDefault(e => e.InvID == saleEntity.InvID);        
            string category = invEntity.Category;
            return category;
        }
        public List<CategorySalesListItem> categorySalesFinder()
        {
            List<SaleListItem> saleList = saleServ.SaleIndex();
            List<CategorySalesListItem> newList = new List<CategorySalesListItem>();

            foreach (var item in saleList)
            {
                CategorySalesListItem catSaleListItem = new CategorySalesListItem();
                catSaleListItem.Category = categoryFinder(item);
                catSaleListItem.SalePrice = item.SalePrice;
                newList.Add(catSaleListItem);
            }
            return newList;
        }
            
            
            
            //keep
        public List<PlatformSalesListItem> VisualizeSales()
        {
            //public List<SaleListItem> SaleIndex()
            int index = 0;
            decimal newTotal = 0;
            List<SaleListItem> saleVisuals = saleServ.SaleIndex();
            List<PlatformSalesListItem> platformVisuals = new List<PlatformSalesListItem>();
            foreach(SaleListItem sale in saleVisuals)
            {
                //index = platformVisuals.Find(p => p.PlatformID == sale.PlatformID)
                    index = platformVisuals.FindIndex(p => p.PlatformID == sale.PlatformID);
                if (index == 0)
                {
                    PlatformSalesListItem mp = new PlatformSalesListItem();
                    mp.PlatformID = sale.PlatformID;
                    mp.SalePrice = sale.SalePrice;
                    platformVisuals.Add(mp);
                }
                else
                {
                    //We know what row this platform is on.
                    //get the SalePrice from that row.
                    //add the saleprice from this sale to the amount we found above.
                    //update the row in platformvisuals with the new sales total.
                    newTotal = platformVisuals[index].SalePrice + sale.SalePrice;
                    platformVisuals[index].SalePrice = newTotal;

                }
            }
                return platformVisuals;
        }
        public string platformNameFinder(int ID)
        {  
            var platEntity = _db.Platforms.SingleOrDefault(e => e.PlatformID == ID);
            var platName = platEntity.PlatformName;           

            return platName;
        }
        //Profit by Platform
        public List<ProfitByCategoryListItem> VisualizeProfitByCategory()
        {            
            int index = 0;
            decimal newProfit = 0;
            List<SaleListItem> saleList = saleServ.SaleIndex();
            List<ProfitByCategoryListItem> profitByCategoryVisuals = new List<ProfitByCategoryListItem>();
            foreach (SaleListItem sale in saleList)
            {                
                index = profitByCategoryVisuals.FindIndex(p => p.Category == categoryFinder(sale));
                if (index == 0) //If this category is not in the output list yet
                {
                    ProfitByCategoryListItem mp = new ProfitByCategoryListItem();
                    mp.Category = categoryFinder(sale);
                    mp.Profit = sale.Profit;
                    profitByCategoryVisuals.Add(mp);
                }
                else
                {
                    //This category was already in the list, now add this profit to the listitem
                    newProfit = profitByCategoryVisuals[index].Profit + sale.Profit;
                    profitByCategoryVisuals[index].Profit = newProfit;
                }
            }
            return profitByCategoryVisuals;
        }

    }

}

