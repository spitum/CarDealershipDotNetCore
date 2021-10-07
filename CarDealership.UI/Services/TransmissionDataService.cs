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
    public class TransmissionDataService : ITransmissionDataService
    {
        private readonly HttpClient _httpClient;
        public TransmissionDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Transmission>> GetTransmissions()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Transmission>>("api/transmission");
        }
    }
}
