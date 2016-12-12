using System.Collections.Generic;

namespace TotaMoviesRental.Core.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}