using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TotaMoviesRental.Models;
using TotaMoviesRental.ViewModels;

namespace TotaMoviesRental.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Random()
        {
            var movie = new Movie { Name = "The Wolf Of Wall Street" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int? year, int? month)
        {
            if (!year.HasValue)
                year = DateTime.Now.Year;
            if (!month.HasValue)
                month = 1;

            return Content($"{year}/{month}");
        }

    }
}