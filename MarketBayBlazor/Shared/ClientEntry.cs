using System.ComponentModel.DataAnnotations;

namespace MarketBayBlazor.Shared
{
    public class ClienteEntry
    {

        [Required]
        public string Name {get;set;} = string.Empty;
        [Required]
        public string Email{get;set;} = string.Empty;
        [Required]
        public string Password{get;set;} = string.Empty;

        public string? MetodoPagamento{get;set;}
        public string? Rua{get;set;}
        public string? CodigoPostal{get;set;}
        public string? Localidade{get;set;}

    }
}