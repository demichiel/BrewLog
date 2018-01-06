using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BrewLog.Models;

namespace BrewLog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<HopForm> HopForms { get; set; }
        public DbSet<HopType> HopTypes { get; set; }
        public DbSet<HopUse> HopUses { get; set; }
        public DbSet<Hop> Hops { get; set; }
        public DbSet<FermentableType> FermentableTypes { get; set; }
        public DbSet<Fermentable> Fermentables { get; set; }
        public DbSet<YeastForm> YeastForms { get; set; }
        public DbSet<YeastType> YeastTypes { get; set; }
        public DbSet<Yeast> Yeasts { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

    }
}
