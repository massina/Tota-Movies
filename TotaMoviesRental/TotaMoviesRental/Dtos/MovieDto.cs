using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TotaMoviesRental.Models;

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

        public DateTime ReleaseDate { get; set; }

        [Range(1, 20)]
        public int NumberInStock { get; set; }

    }
}