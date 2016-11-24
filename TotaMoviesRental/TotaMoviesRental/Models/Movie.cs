using System;
using System.ComponentModel.DataAnnotations;

namespace TotaMoviesRental.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string YoutubeTrailerUrl { get; set; }

        public string PosterImageUrl { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

        public DateTime DateAdded { get; set; }
    }
}