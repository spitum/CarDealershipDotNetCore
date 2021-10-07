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
    public class InteriorColorDataService : IInteriorColorDataService
    {
        private readonly HttpClient _httpClient;
        public InteriorColorDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<InteriorColor>> GetInteriorColors()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<InteriorColor>>("api/InteriorColor");
        }
    }
}
