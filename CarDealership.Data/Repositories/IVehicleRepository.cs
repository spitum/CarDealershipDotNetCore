using Cardealership.Shared.Queries;
using CarDealership.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        IEnumerable<FeaturedVehicle> GetFeaturedVehicles();

        InventoryReport GetInventoryReport(string condition);

        List<Vehicle> GetSelectInventory(string type, decimal? minprice, decimal? maxprice, int? minYear, int? maxYear, string quickSearch);
    }
}
