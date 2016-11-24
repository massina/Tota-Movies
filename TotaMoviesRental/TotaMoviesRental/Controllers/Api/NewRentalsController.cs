using System;
using System.Linq;
using System.Web.Http;
using TotaMoviesRental.Dtos;
using TotaMoviesRental.Models;

namespace TotaMoviesRental.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers
                .Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies
                .Where(m => newRental.MoviesIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok("New rentals succeded");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
