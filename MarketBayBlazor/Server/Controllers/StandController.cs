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
    public class StandController : Controller
    {

        private readonly DatabaseContext _context;

        public StandController(DatabaseContext _context)
        {
            this._context = _context;
	    }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StandFeirante>> Get(int id)
        {
            if (!this._context.StandsFeirantes.Any(stand => stand.ID == id))
                return NotFound();

            var stand = await this._context.StandsFeirantes
                .Where(stand => stand.ID == id)
                .Include(stand => stand.Feirante)
                .ThenInclude(feirante => feirante.Conta)
                .Include(stand => stand.ProdutosStands)
                .ThenInclude(produtosStand => produtosStand.Produto)
                .ThenInclude(produto => produto.Categoria)
                .FirstAsync();

            return Ok(stand);
	    }
    }
}

