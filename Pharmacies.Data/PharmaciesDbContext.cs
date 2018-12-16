using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharmacies.Models;


namespace Pharmacies.Data
{
    public class PharmaciesDbContext : IdentityDbContext<PharmaciesUser>
    {
        public PharmaciesDbContext(DbContextOptions<PharmaciesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<GenericMedicament> GenericMedicaments { get; set; }

        public DbSet<DrugMedicament> DrugMedicaments { get; set; }

        public DbSet<PurchasedAndSoldDrugMedicament> PurchasedAndSoldDrugs { get; set; }

        public DbSet<ReportingPeriod> ReportingPeriods { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          //  builder.ApplyConfiguration(new UserRoleEntityConfiguration());
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
