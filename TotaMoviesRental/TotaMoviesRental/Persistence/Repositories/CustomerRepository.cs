using TotaMoviesRental.Core.Models;
using TotaMoviesRental.Core.Repositories;

namespace TotaMoviesRental.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;
    }
}