using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TotaMoviesRental.Core.Models;
using TotaMoviesRental.Persistence.EntityConfigurations;

namespace TotaMoviesRental.Persistence
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RentalConfigurations());
            modelBuilder.Configurations.Add(new CustomerConfigurations());
            modelBuilder.Configurations.Add(new MovieConfigurations());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}