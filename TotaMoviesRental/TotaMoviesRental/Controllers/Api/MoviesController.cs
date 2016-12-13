using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using TotaMoviesRental.Core;
using TotaMoviesRental.Core.Dtos;
using TotaMoviesRental.Core.Models;

namespace TotaMoviesRental.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var movieDtos = _unitOfWork.Movies
                .GetMoviesWithGenres(query)
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _unitOfWork.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            movie.NumberAvailable = movie.NumberInStock; // TODO: Remove this once you fix it in DbMigrtation.
            _unitOfWork.Movies.Add(movie);
            _unitOfWork.Complete();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _unitOfWork.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _unitOfWork.Complete();
            return Ok();
        }

        // DELETE /api/cusomer/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _unitOfWork.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();
            _unitOfWork.Movies.Remove(movie);
            _unitOfWork.Complete();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }
    }
}
