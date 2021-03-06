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
    public class StateDataService : IStateDataService
    {
        private readonly HttpClient _httpClient;
        public StateDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<State>> GetStates()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<State>>("api/State");
        }
    }
}
