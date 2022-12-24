using System.ComponentModel.DataAnnotations;

namespace MarketBayBlazor.Client.ViewModels 
{
    public class ClienteEntry
    {

        [Required]
        public string? Name {get;set;}
        [Required]
        public string? Email{get;set;}
        [Required]
        public string? Password{get;set;}

        public string? MetodoPagamento{get;set;}
        public string? Rua{get;set;}
        public string? CodigoPostal{get;set;}
        public string? Localidade{get;set;}

    }
}