using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace MarketBayBlazor.Shared;

[Table("Produto")]
public class Produto
{
    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    public string Nome { get; set; } = String.Empty;
    [MaxLength(2048)]
    public string Foto { get; set; } = String.Empty;
    [MaxLength(200)]
    public string Descricao { get; set; } = String.Empty;
    [Precision(10,2)]
    public decimal PrecoBase { get; set; }
    
    [ForeignKey("Categoria")]
    public int CategoriaID { get; set; }
    public virtual Categoria? Categoria { get; set; }
}
