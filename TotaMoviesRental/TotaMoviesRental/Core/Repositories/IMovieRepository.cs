using System.Collections.Generic;
using TotaMoviesRental.Core.Models;

namespace TotaMoviesRental.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetMoviesByReleaseDate(int? year, int? month);
        IEnumerable<Movie> GetMoviesWithGenres(int pageIndex, int pageSize);
        IEnumerable<Movie> GetMoviesWithGenres(string query);
        Movie GetMovieWithGenre(int id);
    }
}