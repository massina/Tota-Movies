using System.Collections.Generic;
using TotaMoviesRental.Models;

namespace TotaMoviesRental.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}