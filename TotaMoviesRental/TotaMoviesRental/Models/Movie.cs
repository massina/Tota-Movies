using System;

namespace TotaMoviesRental.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string YoutubeTrailerUrl { get; set; }
        public string PosterImageUrl { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberInStock { get; set; }
        public DateTime DateAdded { get; set; }
    }
}