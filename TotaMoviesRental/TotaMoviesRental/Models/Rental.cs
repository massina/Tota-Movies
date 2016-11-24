using System;
using System.ComponentModel.DataAnnotations;

namespace TotaMoviesRental.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }
    }
}