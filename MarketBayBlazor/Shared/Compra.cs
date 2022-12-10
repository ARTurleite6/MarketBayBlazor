using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MarketBayBlazor.Shared;

[Table("Compra")]
public class Compra
{
    [Key]
    public int ID { get; set; }
    [Precision(10, 2)]
    public decimal Preco { get; set; }
    public DateTime DataCompra { get; set; }

    [ForeignKey("Cliente")]
    public int ClienteID { get; set; }
    
    [ForeignKey("StandFeirante")]
    public int StandFeiranteID { get; set; }

    public ICollection<CompraProduto> CompraProdutos { get; set; } = new List<CompraProduto>();
}

