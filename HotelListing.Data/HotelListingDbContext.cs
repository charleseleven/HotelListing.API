using HotelListing.API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : IdentityDbContext<ApiUser>
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
        }
    }
    // ** FIX SCAFOOLDING AND MIGRATIONS ** //
    //public class HotelListingDbContextFactory : IDesignTimeDbContextFactory<HotelListingDbContext>
    //{
    //    public HotelListingDbContext CreateDbContext(string[] args)
    //    {
    //        IConfiguration config = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        var optionsBuilder = new DbContextOptionsBuilder<HotelListingDbContext>();
    //        var connectionString = config.GetConnectionString("HotelListingDbConnectionString");
    //        optionsBuilder.UseSqlServer(connectionString);
    //        return new HotelListingDbContext(optionsBuilder.Options);
    //    }
    //}
}