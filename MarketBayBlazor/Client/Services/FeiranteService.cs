namespace MarketBayBlazor.Client.Services;

public class FeiranteService : IFeiranteService
{
    
    private readonly HttpClient _http;

    public FeiranteService(HttpClient _http)
    {
        this._http = _http;
    }

    public async Task RegistaFeirante(FeiranteDTO feirante)
    {
        var result = await _http.PostAsJsonAsync("api/feirante/register", feirante);
        if(result.IsSuccessStatusCode)
        {
            Console.WriteLine("Feirante adicionado com sucesso");
        } 
        else
        {
            Console.WriteLine("Erro a criar feirate, erro = " + result.RequestMessage);
        }
    }
}