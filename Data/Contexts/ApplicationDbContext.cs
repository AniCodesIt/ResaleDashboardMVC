
using Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResaleDashboardMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //1-1
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Sale> Sales { get; set; }
        //1-many
        //many-many
    }
}
