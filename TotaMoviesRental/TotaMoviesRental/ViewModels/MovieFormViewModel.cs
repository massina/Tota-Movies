using System.Collections.Generic;
using TotaMoviesRental.Models;

namespace TotaMoviesRental.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}