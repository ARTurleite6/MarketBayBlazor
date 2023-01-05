using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketBayBlazor.Shared;

[Table("Feirante")]
public class Feirante: IUser
{
    [Key]
    public int ID { get; set; }
    [MaxLength(9)]
    public string NIFempresarial { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Foto { get; set; } = string.Empty;
    public bool Organizador { get; set; } = false;
    
    [ForeignKey("Conta")]
    public int ContaID { get; set; }
    public Conta Conta { get; set; } = new Conta();

    public virtual ICollection<FormularioFeirante> Formularios { get; set; } = new List<FormularioFeirante>();
    public virtual ICollection<ClassificacoesCliente> ClassificacoesClientes { get; set; } = new List<ClassificacoesCliente>();
}