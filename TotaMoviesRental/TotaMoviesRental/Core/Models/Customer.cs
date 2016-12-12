using System;
using System.ComponentModel.DataAnnotations;
using TotaMoviesRental.Core.ValidationAttributes;

namespace TotaMoviesRental.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}