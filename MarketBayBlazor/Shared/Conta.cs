using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketBayBlazor.Shared;

[Table("Conta")]
public class Conta
{

    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    public string Nome { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    public byte[] Password { get; set; }
    public byte[] PasswordSalt { get; set; }
    [MaxLength(9)]
    public string? NumeroTelemovel { get; set; }
    
    [ForeignKey("Morada")]
    public int? MoradaID { get; set; }
    public Morada? Morada { get; set; }

}

