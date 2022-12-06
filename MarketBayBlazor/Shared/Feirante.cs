using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketBayBlazor.Shared;

[Table("Feirante")]
public class Feirante
{
    [Key]
    public int ID { get; set; }
    [MaxLength(9)]
    public string NIFempresarial { get; set; }
    [MaxLength(200)]
    public string Foto { get; set; }
    public bool Organizador { get; set; } = false;
    
    [ForeignKey("Conta")]
    public int ContaID { get; set; }
    public Conta Conta { get; set; }
    
    public virtual ICollection<FormularioFeirante> Formularios { get; set; }
    public virtual ICollection<StandFeirante> Stands { get; set; }
    public virtual ICollection<ClassificacoesCliente> ClassificacoesClientes { get; set; }
}