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

        IEnumerable<InventoryReport> GetInventoryReport(string condition);

        IEnumerable<Vehicle> GetSelectInventory(InventorySearchParameters parameters);
    }
}
