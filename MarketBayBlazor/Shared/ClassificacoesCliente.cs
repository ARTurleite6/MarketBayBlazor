using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace MarketBayBlazor.Shared;

[PrimaryKey("FeiranteID", "ClienteID")]
public class ClassificacoesCliente
{
    [ForeignKey("Feirante")]
    public int FeiranteID { get; set; } 
    [ForeignKey("Cliente")]
    public int ClienteID { get; set; }
    
    [Range(1,5)]
    public int Valor { get; set; }
    [MaxLength(200)]
    public string Descricao { get; set; } = String.Empty;
}