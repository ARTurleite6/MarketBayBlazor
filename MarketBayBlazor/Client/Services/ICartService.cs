namespace MarketBayBlazor.Client.Services;

using MarketBayBlazor.Client.ViewModels.Carrinho;

public interface ICartService
{
    Task<Carrinho> GetCarrinho(int StandID);
    Task<Carrinho> Carrinho { get; }
    Task<bool> AddProduto(Produto produto, decimal preco, int quantidade, int standID);

    Task ClearCarrinho(int StandID);

    Task<Carrinho> RemoveCarrinho(LinhaCarrinho linha, int standID);
}