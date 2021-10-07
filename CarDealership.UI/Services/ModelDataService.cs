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
    public class ModelDataService : IModelDataService
    {
        private readonly HttpClient _httpClient;
        public ModelDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddModel(Model newModel)
        {

            var postResponse = await _httpClient.PostAsJsonAsync("api/model", newModel);

            postResponse.EnsureSuccessStatusCode();
        }



        public async Task<IEnumerable<Model>> GetModels()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Model>>("api/model");
        }

    }
}
