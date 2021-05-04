using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SaleModels
{
    public class SaleDetail
    {
        public int SaleID { get; set; }
        public int PlatformID { get; set; }
        public int InvID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Profit { get; set; }
    }
}
