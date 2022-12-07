using System;

namespace MarketBayBlazor.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
       	}

        public Task<Cliente> GetCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetClientes()
        {
            throw new NotImplementedException();
        }

        public async Task RegistaCliente(Cliente cliente)
        {
            await _httpClient.PostAsJsonAsync("Cliente", cliente);
        }
    }
}

