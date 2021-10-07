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
    public class SpecialDataService : ISpecialDataService
    {
        private readonly HttpClient _httpClient;
        public SpecialDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddSpecial(Special newSpecial)
        {
            var postResponse = await _httpClient.PostAsJsonAsync("api/special", newSpecial);

            postResponse.EnsureSuccessStatusCode();
        }

        public async Task DeleteSpecial(int specialId)
        {
            var postResponse = await _httpClient.DeleteAsync($"api/special/{specialId}");

            postResponse.EnsureSuccessStatusCode();
        }


        public async Task<IEnumerable<Special>> GetSpecial()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Special>>("api/special");
        }
    }
}
