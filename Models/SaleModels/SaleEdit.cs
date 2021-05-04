using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SaleModels
{
   public class SaleEdit
    {
        public int SaleID { get; set; }
        public int PlatformID { get; set; }
        public int InvID { get; set; }
        public int SaleDate { get; set; }
        public int SalePrice { get; set; }
        public int Profit { get; set; }
    }
}
