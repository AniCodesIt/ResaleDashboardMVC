using System.ComponentModel.DataAnnotations;

namespace FusionCharts.Samples.Models.Data
{
    public class Platform
    {
        [Key]
        public int PlatformID { get; set; }
        public string PlatformName { get; set; }
        public decimal Fees { get; set; }
    }
}