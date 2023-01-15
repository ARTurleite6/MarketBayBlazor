namespace MarketBayBlazor.Client.Services
{
    public interface IStandService
    {
        public Task<StandFeirante?> GetStand(int ID);

        public Task DesativaStand(StandFeirante stand);

        public Task<bool> UpdateProdutoStand(ProdutoStand produto);

    }
}