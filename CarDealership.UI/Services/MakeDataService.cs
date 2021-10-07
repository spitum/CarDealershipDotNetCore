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
    public class MakeDataService : IMakeDataService
    {
        private readonly HttpClient _httpClient;
        public MakeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddMake(Make newMake)
        {

            var postResponse = await _httpClient.PostAsJsonAsync("api/make", newMake);

            postResponse.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Make>> GetMakes()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Make>>("api/make");
        }
    }
}
