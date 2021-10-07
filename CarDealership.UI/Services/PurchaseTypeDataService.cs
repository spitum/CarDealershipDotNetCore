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
    public class PurchaseTypeDataService : IPurchaseTypeDataService
    {
        private readonly HttpClient _httpClient;
        public PurchaseTypeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<PurchaseType>> GetPurchaseTypes()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PurchaseType>>("api/PurchaseType");
        }
    }
}
