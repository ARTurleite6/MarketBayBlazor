using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MarketBayBlazor.Shared;

[Table("Cliente")]
public class Cliente: IUser
{
    [Key]
    public int ID { get; set; }
    
    [ForeignKey("Conta")]
    public int ContaID { get; set; }
    public virtual Conta Conta { get; set; } = new Conta();

    public virtual ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
    public virtual ICollection<FavFeirasCliente> FeirasFavoritas { get; set; } = new List<FavFeirasCliente>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

}
