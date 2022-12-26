using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MarketBayBlazor.Server;

[Route("[controller]")]
[ApiController]
public class AuthController: ControllerBase
{
    
    private readonly DatabaseContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(DatabaseContext _context, IConfiguration _configuration)
    {
        this._context = _context;
        this._configuration = _configuration;
    }

    [HttpPost]
    public async Task<ActionResult<string>> Login(UserLoginDTO request)
    {
        if(!this._context.Contas.Any(conta => conta.Email == request.Email))
        {
            return BadRequest("User not found");
        }

        var conta = await this._context.Contas.Where(conta => conta.Email == request.Email).FirstAsync();
        if(!VerifyPasswordHash(conta, request.Password))
        {
            return BadRequest("Password is wrong");
        } 

        string tipo = string.Empty;
        int id = -1;
        if(this._context.Clientes.Any(cliente => cliente.ContaID == conta.ID))
        {
            id = this._context.Clientes.Where(cliente => cliente.ContaID == conta.ID).Select(cliente => cliente.ID).First();
            tipo = "Cliente";
        } 
        else if(this._context.Feirantes.Any(feirante => feirante.ContaID == conta.ID))
        {
            id = this._context.Feirantes.Where(feirante => feirante.ContaID == conta.ID).Select(feirante => feirante.ID).First();
            tipo = "Feirante";
        }

        if(id == -1)
        {
            return BadRequest("Error finding client or feirante");
        }

        string token = CreateToken(conta, tipo, id);
        
        return Ok(token);
    }

    public string CreateToken(Conta conta, string tipo, int id)
    {

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            new Claim(ClaimTypes.Email, conta.Email),
            new Claim(ClaimTypes.Name, conta.Nome),
            new Claim(ClaimTypes.Role, tipo),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(this._configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private bool VerifyPasswordHash(Conta conta, string password)
    {
        using(var hmac = new HMACSHA512(conta.PasswordSalt))
        {
           var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           return computeHash.SequenceEqual(conta.Password);
        }
    }
}