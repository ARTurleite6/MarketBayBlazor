namespace MarketBayBlazor.Client.Services;

using MarketBayBlazor.Client.ViewModels.Carrinho;

public interface ICartService
{
    Task<Carrinho> Carrinho { get; }
    Task AddProduto(Produto produto, decimal preco, int quantidade);
}