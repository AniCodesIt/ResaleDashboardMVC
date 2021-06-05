using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleDashboardMVC.Models
{
    public class PlatformSalesListItem
    {
        public int PlatformID { get; set; }
        public decimal SalePrice { get; set; }
    }
    public class FakeFile
    {
        public string PlatformID { get; set; }
        public decimal SalePrice { get; set; }
    }
}
