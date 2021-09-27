using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardealership.Shared.Queries
{
    public class SalesReport
    {
        public IdentityUser User { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalVehicles { get; set; }
    }
}
