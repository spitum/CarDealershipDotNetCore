using Cardealership.Shared.Queries;
using CarDealership.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.UI.Interfaces
{
    public interface IVehicleDataService
    {
        Task AddVehicle(Vehicle newVehicle);
        Task DeleteVehicle(int vehicleId);
        Task<IEnumerable<FeaturedVehicle>> GetFeatured();
        Task<IEnumerable<Vehicle>> GetInventory(decimal? minPrice, decimal? maxPrice, string quickSearch, int? maxYear, int? minYear, string condition);
        Task<IEnumerable<InventoryReport>> GetInventoryReport(string condition);
        Task<Vehicle> GetVehicleById(int vehicleId);
    }
}
