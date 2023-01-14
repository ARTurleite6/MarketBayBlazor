namespace MarketBayBlazor.Client.ViewModels.Carrinho;

public class LinhaCarrinho
{
    public Produto Produto { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }

    public LinhaCarrinho()
    {
        this.Produto = new Produto();
        this.Preco = 0;
        this.Quantidade = 0;
    }

    public LinhaCarrinho(Produto produto, decimal preco, int quantidade)
    {
        this.Produto = produto;
        this.Preco = preco;
        this.Quantidade = quantidade;
    }
}