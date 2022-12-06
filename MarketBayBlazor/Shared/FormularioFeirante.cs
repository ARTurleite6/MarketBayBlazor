using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketBayBlazor.Shared;

[Table("FormularioFeirante")]
public class FormularioFeirante
{
    [Key]
    public int ID { get; set; }
    [MaxLength(1000)]
    public string Descricao { get; set; }

    public bool Aceite { get; set; } = false;
}