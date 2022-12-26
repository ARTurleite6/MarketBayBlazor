namespace MarketBayBlazor.Client;

public class PropostaService : IPropostaService
{

    private readonly HttpClient _http;

    public PropostaService(HttpClient _http)
    {
        this._http = _http; 
    }

    public async Task<Proposta?> SendProposta(Proposta proposta)
    {
        var response = await this._http.PostAsJsonAsync("Proposta", proposta);
        if(response.IsSuccessStatusCode)
        {
            return proposta;
        }
        return null;
    }
}