using System;

namespace TotaMoviesRental.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IMovieRepository Movies { get; }
        IGenreRepository Genres { get; }
        void Complete();
    }
}
