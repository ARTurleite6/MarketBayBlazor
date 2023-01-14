namespace MarketBayBlazor.Client.Services;
using MarketBayBlazor.Client.ViewModels.Carrinho;
using MarketBayBlazor.Shared;
using Blazored.LocalStorage;

public class CartService : ICartService
{

    private readonly ILocalStorageService _localStorage;


    public Task<Carrinho> Carrinho {
        get => this._localStorage.GetItemAsync<Carrinho>("carrinho").AsTask();
    }

    public CartService(ILocalStorageService localStorage)
    {
        this._localStorage = localStorage;
    }

    public async Task AddProduto(Produto produto, decimal preco, int quantidade)
    {
        var carrinho = await this.Carrinho ?? new Carrinho();
        Console.WriteLine(carrinho.Produtos.Count());
        carrinho.AddProduto(produto, quantidade, preco);
        Console.WriteLine(carrinho.Produtos.Count());
        await this._localStorage.SetItemAsync<Carrinho>("carrinho", carrinho);
    }
}