using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MarketBayBlazor.Shared;

[Table("Cliente")]
public class Cliente
{
    [Key]
    public int ID { get; set; }
    
    [ForeignKey("Conta")]
    public int ContaID { get; set; }
    public virtual Conta Conta { get; set; }

    public virtual ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
    public virtual ICollection<FavFeirasCliente> FeirasFavoritas { get; set; } = new List<FavFeirasCliente>();

    public virtual ICollection<ClassificacoesCliente> ClassificacoesFeirante { get; set; } = new List<ClassificacoesCliente>();
    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}