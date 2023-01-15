using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketBayBlazor.Shared;

[Table("Categoria")]
public class Categoria
{
    [Key]
    public int ID { get; set; }    
    [MaxLength(50)]
    public string Descricao { get; set; } = string.Empty;

    [MaxLength(2048)]
    public string Foto { get; set; } = string.Empty;
}
