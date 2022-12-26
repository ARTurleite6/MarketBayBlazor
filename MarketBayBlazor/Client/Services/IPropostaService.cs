namespace MarketBayBlazor.Client
{
   public interface IPropostaService
   {
        public Task<Proposta?> SendProposta(Proposta proposta);
   } 
}