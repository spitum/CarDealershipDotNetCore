using Cardealership.Shared.Queries;
using CarDealership.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.UI.Interfaces
{
    public interface IPurchaseDataService
    {
        Task<IEnumerable<Purchase>> GetPurchases();

        Task<IEnumerable<SalesReport>> GetSales();

        Task AddPurchase(Purchase newPurchase);
    }
}
