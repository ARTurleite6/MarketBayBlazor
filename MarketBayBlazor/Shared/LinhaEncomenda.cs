namespace MarketBayBlazor.Shared;

public class LinhaEncomenda
{
    public Produto Produto { get; set; } = new Produto();
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}