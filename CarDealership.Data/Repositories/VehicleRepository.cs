using Cardealership.Shared.Queries;
using CarDealership.Data.Data;
using CarDealership.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>,IVehicleRepository
    {

        public VehicleRepository(AppDBContext context) : base(context)
        {
        }

        public IEnumerable<FeaturedVehicle> GetFeaturedVehicles()
        {
            var vehicles = _context.Vehicles.Include(m => m.Make).ThenInclude(mo => mo.Models).Where(f => f.Featured == true).ToList();

            var featured = vehicles.Select(s => new FeaturedVehicle {VehicleID = s.Id, Make = s.Make, Model = s.Model,SalePrice = s.SalePrice,ImageFileName = s.ImageFileName,Year = s.Year }
            );

            return featured;
        }

        public InventoryReport GetInventoryReport(string condition)
        {
            var vehicles = _context.Vehicles.Include(m => m.Make).Include(mo => mo.Model).Include(c => c.Condition).Where(f => f.Condition.Name == condition);

            InventoryReport inventory = vehicles.GroupBy(g => new { Condition = g.Condition.Name, Make = g.Make, g.Year, Model = g.Model })
                .Select(v => new InventoryReport {Make = v.Key.Make,
                                                  Model = v.Key.Model,
                                                  Condition = condition, 
                                                  Count = v.Count(), 
                                                  StockValue = v.Sum(x => Math.Round(Convert.ToDecimal(x.MSRP), 2)) }
                                                   ).FirstOrDefault();

            return inventory;
        }

        public List<Vehicle> GetSelectInventory(string type, decimal? minprice, decimal? maxprice, int? minYear, int? maxYear, string quickSearch)
        {
            var result = _context.Vehicles.Include(m => m.Make).Include(mo => mo.Model).Include(c => c.Condition);
            var inventory = new List<Vehicle>();

            if (!String.IsNullOrEmpty(type))
            {
                inventory.AddRange(result.Where(c => EF.Functions.Like(c.Condition.Name, type.ToLower())));
            }

            if (minprice != null)
            {
                inventory = inventory.Where(s => s.SalePrice >= minprice).ToList();
            }

            if (maxprice != null)
            {
                inventory = inventory.Where(s => s.SalePrice <= maxprice).ToList();
            }


            if (minYear != null)
            {
                inventory = inventory.Where(s => s.Year >= minYear).ToList();
            }

            if (maxYear != null)
            {
                inventory = inventory.Where(s => s.Year <= maxYear).ToList();
            }

            if (!String.IsNullOrEmpty(quickSearch))
            {

                inventory = inventory.Where(x => new[] { x.Model.Name, x.Make.Name, x.Year.ToString() }.Any(s => s.Contains(quickSearch))).ToList();

            }

            return inventory;
        }
    }
}
