using System.Data.Entity.ModelConfiguration;
using TotaMoviesRental.Core.Models;

namespace TotaMoviesRental.Persistence.EntityConfigurations
{
    public class RentalConfigurations : EntityTypeConfiguration<Rental>
    {
        public RentalConfigurations()
        {
            HasKey(r => r.Id);

            Property(r => r.CustomerId).IsRequired();

            Property(r => r.DateRented).IsRequired();

            Property(r => r.MovieId).IsRequired();
        }
    }
}