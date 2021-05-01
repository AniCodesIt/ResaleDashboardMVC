using System.ComponentModel.DataAnnotations;

namespace ResaleDashboardMVC.Data
{
    public class Platform
    {
        [Key]
        public int PlatformID { get; set; }
        public string PlatformName { get; set; }
        public decimal Fees { get; set; }
    }
}