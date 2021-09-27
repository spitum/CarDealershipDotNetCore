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
            return  _context.Vehicles.Include(m => m.Make)
                                        .Include(mo => mo.Model)
                                        .Include(c => c.Condition)
                                        .Include(b => b.BodyStyle)
                                        .Include(co => co.Color)
                                        .Include(ic => ic.InteriorColor)
                                        .Include(t => t.Transmission).Where(f => f.Featured == true)
                                        .Select(s => new FeaturedVehicle {VehicleID = s.Id, Make = s.Make, Model = s.Model,SalePrice = s.SalePrice,ImageFileName = s.ImageFileName,Year = s.Year }).ToList();

        }

        public IEnumerable<InventoryReport> GetInventoryReport(string condition)
        {
            var vehicles =  _context.Vehicles.Include(m => m.Make)
                                        .Include(mo => mo.Model)
                                        .Include(c => c.Condition)
                                        .Include(b => b.BodyStyle)
                                        .Include(co => co.Color)
                                        .Include(ic => ic.InteriorColor)
                                        .Include(t => t.Transmission).Where(f => f.Condition.Name.ToLower() == condition.ToLower()).ToList();

            var inventory = vehicles.GroupBy(g => new { Condition = g.Condition.Name, Make = g.Make.Name,Model = g.Model.Name, g.Year })
                                        .Select(v => new InventoryReport {Make = v.Key.Make,
                                                                          Model = v.Key.Model,
                                                                          Condition = v.Key.Condition, 
                                                                          Year = v.Key.Year,
                                                                          Count = v.Count(), 
                                                                          StockValue = v.Sum(x => Math.Round(Convert.ToDecimal(x.MSRP), 2)) }
                                        ).ToList();

            return inventory;
        }

        public IEnumerable<Vehicle> GetSelectInventory(InventorySearchParameters parameters)
        {
            var result =  _context.Vehicles.Include(m => m.Make)
                                        .Include(mo => mo.Model)
                                        .Include(c => c.Condition)
                                        .Include(b => b.BodyStyle)
                                        .Include(co => co.Color)
                                        .Include(ic => ic.InteriorColor)
                                        .Include(t => t.Transmission).ToList();
            var inventory = new List<Vehicle>();
            inventory = result.ToList();



            if(!String.IsNullOrEmpty(parameters.Condition))
            {
                inventory = inventory.Where(c => c.Condition.Name.ToLower() == parameters.Condition.ToLower()).ToList();
            }



            if (parameters.MinPrice != null)
            {
                inventory = inventory.Where(s => s.SalePrice >= parameters.MinPrice).ToList();
            }

            if (parameters.MaxPrice != null)
            {
                inventory = inventory.Where(s => s.SalePrice <= parameters.MaxPrice).ToList();
            }


            if (parameters.MinYear != null)
            {
                inventory = inventory.Where(s => s.Year >= parameters.MinYear).ToList();
            }

            if (parameters.MaxYear != null)
            {
                inventory = inventory.Where(s => s.Year <= parameters.MaxYear).ToList();
            }

            if (!String.IsNullOrEmpty(parameters.QuickSearch))
            {

                inventory = inventory.Where(x => new[] { x.Model.Name, x.Make.Name, x.Year.ToString() }.Any(s => s.Contains(parameters.QuickSearch))).ToList();

            }

            return inventory.GroupBy(v => v.Id).Select(grp => grp.First()).ToList();
        }
    }
}
