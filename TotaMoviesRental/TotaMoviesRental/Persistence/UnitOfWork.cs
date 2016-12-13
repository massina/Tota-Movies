using TotaMoviesRental.Core;
using TotaMoviesRental.Core.Repositories;
using TotaMoviesRental.Persistence.Repositories;

namespace TotaMoviesRental.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICustomerRepository Customers { get; }
        public IMovieRepository Movies { get; }
        public IGenreRepository Genres { get; }
        public IMembershipTypeRepository MembershipTypes { get; }
        public IRentalRepository Rentals { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Movies = new MovieRepository(context);
            Customers = new CustomerRepository(context);
            Genres = new GenreRepository(context);
            MembershipTypes = new MembershipTypeRepository(context);
            Rentals = new RentalRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}