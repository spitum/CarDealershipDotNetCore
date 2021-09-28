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
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {

        public PurchaseRepository(AppDBContext context) : base(context)
        {
        }

        public List<SalesReport> GetSalesReport(SalesReportSearchParameters parameters)
        {
            var result = _context.Purchases.Include(u => u.User).ToList();
            var sales = new List<Purchase>();
            sales = result.ToList();

            if (!String.IsNullOrEmpty(parameters.UserName))
            {
                sales = sales.Where(c => c.User.UserName.ToLower() == parameters.UserName.ToLower()).ToList();
            }

            if (parameters.FromDate != null)
            {
                sales = sales.Where(s => s.PurchaseDate >= parameters.FromDate).ToList();
            }

            if (parameters.ToDate != null)
            {
                sales = sales.Where(s => s.PurchaseDate <= parameters.ToDate).ToList();
            }

            List<SalesReport> salesReport = sales.GroupBy(g => new { g.User})
                .Select(v => new SalesReport
                {
                    User = v.Key.User,
                    TotalSales = v.Sum(x => Math.Round(Convert.ToDecimal(x.PurchasePrice), 2)),
                    TotalVehicles = v.Count()
                }
                ).ToList();

            return salesReport;
        }
    }
}
