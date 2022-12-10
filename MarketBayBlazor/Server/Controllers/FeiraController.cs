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
    public class FeiraController : Controller
    {
        private readonly DatabaseContext _context;

        public FeiraController(DatabaseContext _context)
        {
            this._context = _context;
    	}

        [HttpPost]
        public async Task<ActionResult<Feira>> CreateFeira(Feira feira)
        {
            this._context.Feiras.Add(feira);
            await this._context.SaveChangesAsync();
            return Ok(feira);
	    }

        [HttpPost("Inscrever")]
        public async Task<ActionResult<StandFeirante>?> InscreveFeira(int id, StandFeirante stand)
        { 
            if(!this._context.Feiras.Any(feira => feira.ID == id))
            {
                return NotFound("Feira não existente");
	        }

            //Ver se já atingiu o limite de feirantes na feira
            var feira = this._context.Feiras.Where(feira => feira.ID == id).Include(feira => feira.Stands.Where(s => s.ativo == true)).First();
            var numero_participantes = feira.Stands.Count;
            if(numero_participantes >= feira.NumeroMaximoFeirantes || feira.Stands.Any(s => s.FeiranteID == stand.FeiranteID) || feira.DataFim <= DateTime.Now)
            {
                return null;
	        }

            await this._context.StandsFeirantes.AddAsync(stand);
            await this._context.SaveChangesAsync();
            return Ok(stand);
	    }

        [HttpGet]
        public ActionResult<List<Feira>> Get()
        {
            return Ok(_context
                .Feiras
                .Include(feira => feira.Categoria));
    	}

        [HttpGet("Stands/{id:int}")]
        public ActionResult<List<StandFeirante>> GetStands(int id)
        {

            if(!this._context.Feiras.Any(feira => feira.ID == id))
            {
                return NotFound();
	        }

            var stands = _context
                .StandsFeirantes
                .Where(stand => stand.FeiraID == id)
                .Include(stand => stand.Feirante)
                .ThenInclude(feirante => feirante.Conta)
                .Include(stand => stand.ProdutosStands.Where(produto => produto.Destacado))
                .ToList();

            return Ok(stands);
    	}
    }
}

