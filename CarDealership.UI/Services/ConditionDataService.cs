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
    public class ConditionDataService : IConditionDataService
    {
        private readonly HttpClient _httpClient;
        public ConditionDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Condition>> GetConditions()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Condition>>("api/condition");
        }
    }
}

