namespace MarketBayBlazor.Shared;
using System.ComponentModel.DataAnnotations;

public class DadosPagamento
{
    [MinLength(9), MaxLength(9), Required]
    public string? NumeroTelemovel { get; set; } = string.Empty;

    [Required]
    public string? Rua { get; set; } = string.Empty;

    public string? Localidade { get; set; } = string.Empty;

    [Required, MinLength(8), MaxLength(8)]
    public string? Codigo_Postal { get; set; } = string.Empty;

    public List<LinhaEncomenda> Produtos = new List<LinhaEncomenda>();


}