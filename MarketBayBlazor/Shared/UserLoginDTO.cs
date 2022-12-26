using System.ComponentModel.DataAnnotations;

namespace MarketBayBlazor.Shared;

public class UserLoginDTO
{
    [Required]
    public string Email {get; set;} = string.Empty;
    [Required]
    public string Password{get;set;} = string.Empty;
}