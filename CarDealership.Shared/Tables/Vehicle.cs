using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Shared
{
    public class Vehicle
    {
        public int Id { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public Condition Condition { get; set; }
        public BodyStyle BodyStyle { get; set; }

        [Required]
        public int Year { get; set; }
        public Transmission Transmission { get; set; }
        public Color Color { get; set; }
        public InteriorColor InteriorColor { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public string VINNumber { get; set; }

        [Required]
        public decimal MSRP { get; set; }

        [Required]
        public decimal? SalePrice { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageFileName { get; set; }
        public bool Featured { get; set; } = false;
        public DateTime CreatedDate { get; set; }
    }
}
