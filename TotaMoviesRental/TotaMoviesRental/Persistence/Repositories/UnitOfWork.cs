using TotaMoviesRental.Core.Repositories;

namespace TotaMoviesRental.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICustomerRepository Customers { get; }
        public IMovieRepository Movies { get; }
        public IGenreRepository Genres { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
            Customers = new CustomerRepository(_context);
            Genres = new GenreRepository(_context);
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