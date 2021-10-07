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
    public class ColorDataService : IColorDataService
    {
        private readonly HttpClient _httpClient;
        public ColorDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Color>> GetColors()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Color>>("api/color");
        }
    }
}
