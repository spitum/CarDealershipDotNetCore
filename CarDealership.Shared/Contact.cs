using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Shared
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "Contact Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
