namespace MarketBayBlazor.Client.ViewModels.Carrinho;

public class Carrinho { 
    public List<LinhaCarrinho> Produtos { get; set; } = new List<LinhaCarrinho>();

    public void AddProduto(Produto produto, int quantidade, decimal preco)
    {
        this.Produtos.Add(new LinhaCarrinho(produto: produto, quantidade: quantidade, preco: preco));
    }
}