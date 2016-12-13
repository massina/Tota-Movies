using TotaMoviesRental.Core.Models;
using TotaMoviesRental.Core.Repositories;

namespace TotaMoviesRental.Persistence.Repositories
{
    public class MembershipTypeRepository : Repository<MembershipType>,IMembershipTypeRepository
    {
        public MembershipTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}