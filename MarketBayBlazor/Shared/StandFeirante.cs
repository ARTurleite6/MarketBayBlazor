using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MarketBayBlazor.Shared;

[Table("StandFeirante")]
public class StandFeirante
{
    [Key]
    public int ID { get; set; }
    public bool ativo { get; set; } = true;

    [ForeignKey("Feirante")]
    public int FeiranteID { get; set; }
    public virtual Feirante Feirante { get; set; }

    [ForeignKey("Feira")]
    public int FeiraID { get; set; }
    public virtual Feira Feira { get; set; }
    
    public virtual ICollection<ProdutoStand> ProdutosStands{get; set; }
    public virtual ICollection<Proposta> Propostas { get; set; }
    public virtual ICollection<Compra> Vendas { get; set; }
}