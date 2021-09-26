using CarDealership.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardealership.Shared.Queries
{
    public class FeaturedVehicle
    {
        public int VehicleID { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public decimal? SalePrice { get; set; }
        public string ImageFileName { get; set; }
        public int Year { get; set; }
    }
}
