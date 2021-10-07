using Cardealership.Shared.Queries;
using CarDealership.Shared;
using CarDealership.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarDealership.UI.Services
{
    public class PurchaseDataService : IPurchaseDataService
    {
        private readonly HttpClient _httpClient;
        public PurchaseDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddPurchase(Purchase newPurchase)
        {
            var postResponse = await _httpClient.PostAsJsonAsync("api/purchase", newPurchase);

            postResponse.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Purchase>> GetPurchases()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Purchase>>("api/purchase");
        }

        public async Task<IEnumerable<SalesReport>> GetSales()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<SalesReport>>("api/purchase/salesreport");
        }
    }
}
