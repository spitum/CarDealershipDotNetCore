using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Shared
{
    public class Purchase
    {
        public int Id { get; set; }

        public IdentityUser User { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public State State { get; set; }
        [Required]
        public int ZipCode { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }
        public PurchaseType PurchaseType { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }
    }
}
