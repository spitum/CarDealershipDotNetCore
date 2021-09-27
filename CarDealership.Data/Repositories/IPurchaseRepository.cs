using Cardealership.Shared.Queries;
using CarDealership.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {
        List<SalesReport> GetSalesReport(SalesReportSearchParameters parameters);
    }
}
