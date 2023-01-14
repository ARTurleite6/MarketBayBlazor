using System;
namespace MarketBayBlazor.Client.Services
{
    public interface IFeiraService
    {

        public Task<List<Feira>?> GetFeiras();
        public Task<List<StandFeirante>?> GetStandsFeira(int id);

        public Task<Feira?> GetFeira(int id);

        public Task InscreveEmFeira(FeiraSubmitDTO request);

        public Task<List<Feira>?> GetFeirasOrganizador(int id);

        public Task<bool> CreateFeira(Feira feira);

    }
}

