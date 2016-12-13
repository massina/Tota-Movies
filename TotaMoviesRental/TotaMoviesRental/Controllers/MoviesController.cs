using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TotaMoviesRental.Core;
using TotaMoviesRental.Core.Models;
using TotaMoviesRental.Core.Repositories;
using TotaMoviesRental.Core.ViewModels;

namespace TotaMoviesRental.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult Details(int id)
        {
            var movie = _unitOfWork.Movies.GetMovieWithGenre(id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _unitOfWork.Genres.GetAll()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _unitOfWork.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _unitOfWork.Genres.GetAll()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _unitOfWork.Genres.GetAll()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock; // TODO: Remove this once you fixed it in DbMigrtation.
                _unitOfWork.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _unitOfWork.Movies.Single(m => m.Id == movie.Id);
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Name = movie.Name;
                movieInDb.PosterImageUrl = movie.PosterImageUrl;
                movieInDb.YoutubeTrailerUrl = movie.YoutubeTrailerUrl;
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}