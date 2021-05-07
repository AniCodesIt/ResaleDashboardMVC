using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FusionCharts.Samples.Models.Data
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        [ForeignKey(nameof(Platform))]
        public int PlatformID { get; set; }
        public virtual Platform Platform { get; set; }

        [ForeignKey(nameof(Inventory))]
        public int InvID { get; set; }
        public virtual Inventory Inventory { get; set; }
        public DateTime SaleDate { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
        public decimal Profit { get; set; }

    }
}