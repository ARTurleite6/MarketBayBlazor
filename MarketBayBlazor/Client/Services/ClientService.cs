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

        public async Task<Cliente?> GetCliente(int id)
        {
            var res = await this._httpClient.GetFromJsonAsync<Cliente>($"api/cliente/{id}");
            return res;
        }

        public Task GetClientes()
        {
            throw new NotImplementedException();
        }

        public async Task RegistaCliente(ClienteEntry cliente)
        {
            await _httpClient.PostAsJsonAsync("api/Cliente", cliente);
        }

        public async Task<bool> RegistaCompra(Compra compra)
        {
            var res = await _httpClient.PostAsJsonAsync("api/cliente/compra", compra);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var res = await this._httpClient.PutAsJsonAsync("api/cliente", cliente);
            if(res.IsSuccessStatusCode)
            {
                Console.WriteLine("alteração bem sucedida");
                return true;
            }
            else
            {
                Console.WriteLine("Ocorreu um erro alterando o cliente");
                return false;
            }
        }
    }
}

