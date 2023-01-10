namespace MarketBayBlazor.Client.Services;

public class CategoriaService : ICategoriaService
{

    private readonly HttpClient _http;

    public CategoriaService(HttpClient _http)
    {
        this._http = _http; 
    }

    public Task<List<Categoria>?> GetCategorias()
    {
        return this._http.GetFromJsonAsync<List<Categoria>>("api/categoria");
    }
}