using System.Collections.Generic;
using TotaMoviesRental.Core.Models;

namespace TotaMoviesRental.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerWithGenre(int id);
        IEnumerable<Customer> GetCustomersWithMembershipTypes(string query);
    }
}