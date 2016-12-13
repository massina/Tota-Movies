using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TotaMoviesRental.Core.Models;
using TotaMoviesRental.Core.Repositories;

namespace TotaMoviesRental.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        private ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public Customer GetCustomerWithGenre(int id)
        {
            return ApplicationDbContext.Customers.Include(m => m.MembershipType).SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Customer> GetCustomersWithMembershipTypes(string query)
        {
            var customersQuery = ApplicationDbContext.Customers
              .Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            return customersQuery.ToList();
        }
    }
}