namespace MarketBayBlazor.Client
{
   public interface IPropostaService
   {
        public Task<Proposta?> SendProposta(Proposta proposta);

        public Task<List<Proposta>?> GetPropostasStand(int standID);

        public Task UpdateProposta(Proposta proposta);
   } 
}