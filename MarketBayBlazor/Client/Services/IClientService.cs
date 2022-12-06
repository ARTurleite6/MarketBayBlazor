using System;
namespace MarketBayBlazor.Client.Services
{
    public interface IClientService
    {

        public List<Cliente> Clientes { get; set; }

        public Task GetClientes();
        public Task<Cliente> GetCliente(int id);

        public Task RegistaCliente(Cliente cliente);
    }
}

