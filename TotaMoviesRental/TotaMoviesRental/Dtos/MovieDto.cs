using System;
using System.ComponentModel.DataAnnotations;

namespace TotaMoviesRental.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string YoutubeTrailerUrl { get; set; }

        public string PosterImageUrl { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }

    }
}