namespace MarketBayBlazor.Client.Services;

public interface IProdutoService 
{

    public Task<List<Produto>?> GetProdutos(int categoriaID);
}