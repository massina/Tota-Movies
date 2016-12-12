using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TotaMoviesRental.Core.Models;
using TotaMoviesRental.Core.Repositories;

namespace TotaMoviesRental.Persistence.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Movie> GetMoviesByReleaseDate(int? year, int? month)
        {
            if (!year.HasValue)
                year = DateTime.Now.Year;

            if (!month.HasValue)
                month = 1;

            return ApplicationDbContext.Movies
                .Where(m => m.ReleaseDate.Year == year && m.ReleaseDate.Month == month)
                .ToList();
        }

        public IEnumerable<Movie> GetMoviesWithGenres(int pageIndex, int pageSize = 10)
        {
            return ApplicationDbContext.Movies
                    .Include(m => m.Genre)
                    .OrderBy(m => m.Name)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }

        public Movie GetMovieWithGenre(int id)
        {
            return ApplicationDbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
        }


        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;
    }
}