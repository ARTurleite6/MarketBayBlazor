namespace MarketBayBlazor.Client;

public class PropostaService : IPropostaService
{

    private readonly HttpClient _http;

    public PropostaService(HttpClient _http)
    {
        this._http = _http; 
    }

    public async Task UpdateProposta(Proposta proposta)
    {
        var res = await this._http.PutAsJsonAsync($"api/proposta/{proposta.ID}", proposta);
        if(res.IsSuccessStatusCode)
        {
            Console.WriteLine("Proposta Aceite com sucesso");
        }
    }

    public async Task<List<Proposta>?> GetPropostasStand(int standID)
    {
        var response = await this._http.GetFromJsonAsync<List<Proposta>>($"api/Proposta/{standID}");
        return response;
    }

    public async Task<Proposta?> SendProposta(Proposta proposta)
    {
        var response = await this._http.PostAsJsonAsync("api/Proposta", proposta);
        if(!response.IsSuccessStatusCode) return null;
        return proposta;
    }
}