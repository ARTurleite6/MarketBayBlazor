using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MarketBayBlazor.Shared;

[Table("CompraProduto")]
[PrimaryKey("CompraID", "ProdutoID")]
public class CompraProduto
{
    [ForeignKey("Compra")]
    public int CompraID { get; set; }
    [ForeignKey("Produto")]
    public int ProdutoID { get; set; }
    public virtual Produto? Produto { get; set; }
    
    public int Quantidade { get; set; }
    [Precision(10, 2)]
    public decimal Preco { get; set; }
}