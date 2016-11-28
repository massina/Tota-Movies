using System.ComponentModel.DataAnnotations;

namespace TotaMoviesRental.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}