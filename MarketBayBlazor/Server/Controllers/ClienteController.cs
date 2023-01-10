using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketBayBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {

        private readonly DatabaseContext _context;

        public ClienteController(DatabaseContext _context)
        {
            this._context = _context;
       	}

        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(this._context
		        .Clientes
	            .Include(cliente => cliente.Conta).ToList());
	    }

        [HttpPost]
        public async Task<ActionResult<Cliente>> RegistaCliente(ClienteEntry cliente) 
    	{

            CreatePasswordHash(cliente.Password, out byte[] passwordHash, out byte[] passwordSalt);

            Morada? morada = null;
            if(cliente.CodigoPostal != null && cliente.Rua != null && cliente.Localidade != null)
            {
                morada = new Morada()
                {
                    CodigoPostal = cliente.CodigoPostal,
                    Localidade = cliente.Localidade,
                    Rua = cliente.Rua,
                };
            }

            var clienteModel = new Cliente()
            {
                Conta = new Conta()
                {
                    Nome = cliente.Name,
                    Email = cliente.Email,
                    Password = passwordHash,
                    PasswordSalt = passwordSalt,
                    NumeroTelemovel = cliente.MetodoPagamento,
                    Morada = morada,
                },
            };

            this._context.Add(clienteModel);
            await this._context.SaveChangesAsync(); 

            return Ok(cliente);
    	}

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}

