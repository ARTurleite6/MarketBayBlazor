using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketBayBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeiranteController : Controller
    {
        private readonly DatabaseContext _context;
        public FeiranteController(DatabaseContext _context)
        {
            this._context = _context;
	    }

        [HttpGet]
        public async Task<ActionResult<List<Feirante>>> GetFeirantes()
        {
            var feirantes = await this._context.Feirantes
                .Include(feirante => feirante.Conta)
		        .ToListAsync();

            return Ok(feirantes);
	    }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Feirante>> GetFeirante(int id)
        {
            if (!this._context.Feirantes.Any(Feirante => Feirante.ID == id))
                return NotFound();

            var feirante = await this._context.Feirantes
                .Where(feirante => feirante.ID == id)
                .Include(feirante => feirante.Conta)
                .ThenInclude(feirante => feirante.Morada)
                .FirstAsync();
            return Ok(feirante);
        }

        [HttpGet("Formularios/{id:int}")]
        public async Task<ActionResult<List<ClassificacoesCliente>>> GetClassificacoes(int id)
        {
            var classificacoes = await this._context
                .ClassificacoesCliente
                .Where(classificacao => classificacao.FeiranteID == id)
                .Include(cliente => cliente.Cliente)
                .ThenInclude(cliente => cliente.Conta)
                .ToListAsync();

            return Ok(classificacoes);
	    }
    }
}

