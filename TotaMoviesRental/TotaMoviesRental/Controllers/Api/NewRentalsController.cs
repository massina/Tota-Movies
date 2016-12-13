using System;
using System.Linq;
using System.Web.Http;
using TotaMoviesRental.Core;
using TotaMoviesRental.Core.Dtos;
using TotaMoviesRental.Core.Models;

namespace TotaMoviesRental.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewRentalsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST /api/newrentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MoviesIds == null || newRental.MoviesIds.Count == 0)
                return BadRequest("No movie Ids have been given.");

            var customer = _unitOfWork.Customers
                .SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Customer Id is invalid.");

            var movies = _unitOfWork.Movies
                .Find(m => newRental.MoviesIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MoviesIds.Count)
                return BadRequest("One or more movie Ids are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _unitOfWork.Rentals.Add(rental);

            }

            _unitOfWork.Complete();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }
    }
}
