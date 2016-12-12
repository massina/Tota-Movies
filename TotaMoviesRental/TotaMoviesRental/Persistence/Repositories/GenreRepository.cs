using TotaMoviesRental.Core.Models;
using TotaMoviesRental.Core.Repositories;

namespace TotaMoviesRental.Persistence.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;
    }
}