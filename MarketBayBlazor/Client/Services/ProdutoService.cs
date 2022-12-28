namespace MarketBayBlazor.Client.Services;

public class ProdutoService : IProdutoService
{

    private readonly HttpClient _http;

    public ProdutoService(HttpClient _http)
    {
        this._http = _http;
    }


    public async Task<List<Produto>?> GetProdutos(int categoriaID)
    {
        Console.WriteLine($"Produto/{categoriaID}");
        try {
            var result = await this._http.GetFromJsonAsync<List<Produto>>($"api/produto/{categoriaID}");
            if (result == null) return null;

            return result;
        } catch (Exception e){
            Console.WriteLine(e.Message);
            return null;
        }

    }
}