using BlazorFunitureStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFunitureStore.Client.Sevices
{
    public class ClientsService : IClientsService
    {
        private readonly HttpClient _httpClient;
        public ClientsService(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Clients>> GetAllClients()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Clients>>($"api/clients");
        }
    }
}
