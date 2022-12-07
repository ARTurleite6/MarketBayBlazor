using System;
namespace MarketBayBlazor.Client.Services
{
    public interface IFeiraService
    {

        public Task<List<Feira>> GetFeiras();

    }
}

