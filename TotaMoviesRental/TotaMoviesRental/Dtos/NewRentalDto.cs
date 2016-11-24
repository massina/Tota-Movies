using System.Collections.Generic;

namespace TotaMoviesRental.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}