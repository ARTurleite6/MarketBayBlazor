using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MarketBayBlazor.Shared;

[Table("Proposta")]
public class Proposta
{
   [Key]
   public int ID { get; set; } 
   
   [Precision(10, 2)]
   public decimal Preco { get; set; }
   [MaxLength(1000)]
   public string Descricao { get; set; }
   public int Quantidade { get; set; }
   [MaxLength(50)]
   public string Estado{ get; set; } = "Pendente";
   public DateTime data { get; set; } = DateTime.Now;
   
   [ForeignKey("Produto")]
   public int ProdutoID { get; set; } 
   public virtual Produto Produto { get; set; }
   [ForeignKey("Cliente")]
   public int ClienteID { get; set; }
   public virtual Cliente Cliente { get; set; }
   [ForeignKey("StandFeirante")]
   public int StandFeiranteID { get; set; }
}