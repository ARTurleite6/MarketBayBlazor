using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketBayBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly DatabaseContext _context; 
        public UserController(DatabaseContext _context) 
	    {
            this._context = _context;
	    }

        [HttpPost("{email}/{password}")]
        public async Task<ActionResult<IUser>> Login(string email, string password)
        {
            if (!this._context.Contas.Any(conta => conta.Email == email)) 
		        return NotFound();

            var conta = await this._context.Contas.Where(conta => conta.Email == email).Include(cliente => cliente.Morada).FirstAsync();

            if(conta.Password == password)
            {
                if(this._context.Feirantes.Any(feirante => feirante.ContaID == conta.ID))
                {
                    var feirante = await this._context.Feirantes.Where(feirante => feirante.ContaID == conta.ID).Include(f => f.Conta).ThenInclude(c => c.Morada).FirstAsync();
                    return Ok(feirante);
		        }
                else if(this._context.Clientes.Any(cliente => cliente.ContaID == conta.ID))
                {
                    var cliente = await this._context.Clientes.Where(c => c.ContaID == conta.ID).Include(c => c.Conta).ThenInclude(c => c.Morada).FirstAsync();
                    return Ok(cliente);
		        }
	        }
            return NotFound();
    	}

    }
}

