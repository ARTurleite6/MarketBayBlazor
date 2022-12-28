namespace MarketBayBlazor.Shared;

public class FeiraSubmitDTO
{
    public int FeiranteID { get; set; } 
    public int FeiraID { get; set; }
    public List<int> Produtos { get; set; } = new List<int>();
    public HashSet<int> ProdutosDestacados{ get; set; } = new HashSet<int>();
    public Dictionary<int, decimal> ProdutoPreco {get; set;} = new Dictionary<int, decimal>();

    public Dictionary<int, int> QuantidadeProduto {get; set;} = new Dictionary<int, int>();

}