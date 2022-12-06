using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MarketBayBlazor.Shared;

[Table("Feira")]
public class Feira
{
    [Key]
    public int ID { get; set; }
    [MaxLength(100)]
    public string NomeFeira { get; set; }
    [MaxLength(200)]
    public string Logotipo { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    [Precision(10, 2)]
    public decimal PrecoAluguel { get; set; }
    public int NumeroMaximoFeirantes { get; set; }

    [ForeignKey("Feirante")]
    public int FeiranteID { get; set; }
    public virtual Feirante Organizador { get; set; }
    
    [ForeignKey("Categoria")]
    public int CategoriaID{ get; set;}
    public Categoria Categoria { get; set; }
    
    public virtual ICollection<StandFeirante> Stands { get; set; }
}