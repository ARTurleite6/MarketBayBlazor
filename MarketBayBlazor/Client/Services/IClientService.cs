using System;
namespace MarketBayBlazor.Client.Services
{
    public interface IClientService
    {


        public Task GetClientes();
        public Task<Cliente> GetCliente(int id);

        public Task RegistaCliente(ClienteEntry cliente);
    }
}

