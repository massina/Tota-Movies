using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TotaMoviesRental.Core.Models;

namespace TotaMoviesRental.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string YoutubeTrailerUrl { get; set; }

        public string PosterImageUrl { get; set; }

        [Required]
        public byte? GenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        public string Title => Id == 0 ? "New Movie" : "Edit Movie";

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
            PosterImageUrl = movie.PosterImageUrl;
            YoutubeTrailerUrl = movie.YoutubeTrailerUrl;
        }
    }
}