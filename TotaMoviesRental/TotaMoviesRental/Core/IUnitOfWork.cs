using System;
using TotaMoviesRental.Core.Repositories;

namespace TotaMoviesRental.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IMovieRepository Movies { get; }
        IGenreRepository Genres { get; }
        IMembershipTypeRepository MembershipTypes { get; }
        IRentalRepository Rentals { get; }
        void Complete();
    }
}
