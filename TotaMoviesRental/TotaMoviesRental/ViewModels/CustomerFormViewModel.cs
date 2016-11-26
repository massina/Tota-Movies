using System.Collections.Generic;
using TotaMoviesRental.Models;

namespace TotaMoviesRental.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title { get; set; }
    }
}