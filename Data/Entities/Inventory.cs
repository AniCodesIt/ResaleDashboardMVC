using System.ComponentModel.DataAnnotations;

namespace FusionCharts.Samples.Models.Data
{ 
        public class Inventory
        {
            [Key]
            public int InvID { get; set; }
            public string Brand { get; set; }
            public string Category { get; set; }
            public string Color { get; set; }
            public string Size { get; set; }
            public string Description { get; set; }
            public string Source { get; set; }
            public decimal COG { get; set; }
            public int StockOnHand { get; set; }
            public string Location { get; set; }
        }
    
}