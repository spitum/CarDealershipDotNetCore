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
    public class ContactDataService : IContactDataService
    {
        private readonly HttpClient _httpClient;
        public ContactDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Contact> AddContact(Contact newContact)
        {
            var response = await _httpClient.PostAsJsonAsync("api/contact", newContact);

            if (response.IsSuccessStatusCode)
            {
                return await _httpClient.GetFromJsonAsync<Contact>($"api/contact/{newContact.Id}");
            }

            return null;


            
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>("api/contact");
        }
    }
}
