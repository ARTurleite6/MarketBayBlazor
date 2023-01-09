namespace MarketBayBlazor.Client.Services;

public class FeiranteService : IFeiranteService
{
    
    private readonly HttpClient _http;

    public FeiranteService(HttpClient _http)
    {
        this._http = _http;
    }

    public async Task<bool> RegistaFeirante(FeiranteDTO feirante)
    {
        var result = await _http.PostAsJsonAsync("api/feirante/register", feirante);
        if(result.IsSuccessStatusCode)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }

    public async Task<Feirante?> GetFeirante(int ID)
    {
        var feirante = await _http.GetFromJsonAsync<Feirante>($"api/feirante/{ID}");
        return feirante;
    }
}