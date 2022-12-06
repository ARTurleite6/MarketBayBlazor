using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MarketBayBlazor.Shared;

[Table("FavFeirasCliente")]
[PrimaryKey("ClienteID", "FeiraID")]
public class FavFeirasCliente
{
    [ForeignKey("Cliente")]
    public int ClienteID;
    [ForeignKey("Feira")]
    public int FeiraID;
}