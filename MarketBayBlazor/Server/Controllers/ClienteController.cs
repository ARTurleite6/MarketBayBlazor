using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarketBayBlazor.Shared;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketBayBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {

        private readonly DatabaseContext _context;

        public ClienteController(DatabaseContext _context)
        {
            this._context = _context;
       	}

        [HttpPost]
        public async Task<ActionResult<Cliente>> RegistaCliente(Cliente cliente) 
    	{
            var conta = cliente.Conta;
            this._context.Add(conta);
            this._context.Add(cliente);
            await this._context.SaveChangesAsync(); 
            return Ok(cliente);
    	}

    }
}

