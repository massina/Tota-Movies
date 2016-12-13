using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TotaMoviesRental.Core.Models;
using TotaMoviesRental.Core.ValidationAttributes;

namespace TotaMoviesRental.Core.ViewModels
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            MembershipTypeId = customer.MembershipTypeId;
            Birthdate = customer.Birthdate;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public string Title => Id == 0 ? "New Customer" : "Edit Customer";
    }
}