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
    public class BodyStyleDataService : IBodyStyleDataService
    {

        private readonly HttpClient _httpClient;

        public BodyStyleDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BodyStyle>> GetBodyStyles()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BodyStyle>>("api/bodystyle");
        }
    }
}
