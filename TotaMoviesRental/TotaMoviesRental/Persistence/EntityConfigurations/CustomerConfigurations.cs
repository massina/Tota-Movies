using System.Data.Entity.ModelConfiguration;
using TotaMoviesRental.Core.Models;

namespace TotaMoviesRental.Persistence.EntityConfigurations
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            HasKey(m => m.Id);

            Property(c => c.Name).HasMaxLength(30).IsRequired();

            Property(c => c.Birthdate).IsOptional();

            Property(m => m.MembershipTypeId).IsRequired();
        }
    }
}