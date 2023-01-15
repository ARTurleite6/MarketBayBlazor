namespace MarketBayBlazor.Client.Services;
using MarketBayBlazor.Client.ViewModels.Carrinho;
using MarketBayBlazor.Shared;
using Blazored.LocalStorage;

public class CartService : ICartService
{

    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;


    public Task<Carrinho> Carrinho {
        get => this._localStorage.GetItemAsync<Carrinho>("carrinho").AsTask();
    }

    public CartService(ILocalStorageService localStorage, HttpClient _http)
    {
        this._localStorage = localStorage;
        this._http = _http;
    }

    public Task<Carrinho> GetCarrinho(int StandID)
    {
        return this._localStorage.GetItemAsync<Carrinho>($"carrinho{StandID}").AsTask();
    }

    public async Task<bool> AddProduto(Produto produto, decimal preco, int quantidade, int standID)
    {
        var carrinho = await this.GetCarrinho(standID) ?? new Carrinho();
        var res = await this._http.PutAsJsonAsync<int>($"api/stand/reservaproduto/{standID}/{produto.ID}/{quantidade}", quantidade);
        if(!res.IsSuccessStatusCode) return false;
        Console.WriteLine(carrinho.Produtos.Count());
        carrinho.AddProduto(produto, quantidade, preco);
        Console.WriteLine(carrinho.Produtos.Count());
        await this._localStorage.SetItemAsync<Carrinho>($"carrinho{standID}", carrinho);
        return true;
    }

    public async Task ClearCarrinho(int standID)
    {
        await this._localStorage.RemoveItemAsync($"carrinho{standID}");     
    }

    public async Task<Carrinho> RemoveCarrinho(LinhaCarrinho linha, int standID)
    {
        var carrinho = await this._localStorage.GetItemAsync<Carrinho>($"carrinho{standID}");
        if(carrinho != null)
        {
            int index = -1;
            for(int i = 0; i < carrinho.Produtos.Count(); ++i)
            {
                var produto = carrinho.Produtos[i];
                if(produto.Produto.ID == linha.Produto.ID && produto.Preco == linha.Preco && produto.Quantidade == linha.Quantidade)
                {
                    index = i;
                    break;
                }
            }
            if(index != -1)
            {
                carrinho.Produtos.RemoveAt(index);
                var res = await this._http.PutAsJsonAsync($"api/stand/adicionaproduto/{standID}/{linha.Produto.ID}/{linha.Quantidade}", linha.Quantidade);
                if(res.IsSuccessStatusCode)
                {
                    await this._localStorage.SetItemAsync<Carrinho>($"carrinho{standID}", carrinho);
                }
                return carrinho;
            }
            return carrinho;
        }
        return new Carrinho();
    }
}