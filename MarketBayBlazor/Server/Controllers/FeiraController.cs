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
    [Route("api/[controller]")]
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

        [HttpPost("Inscrever/{id:int}")]
        public async Task<ActionResult<StandFeirante>?> InscreveFeira(int id, FeiraSubmitDTO request)
        { 

            if(!this._context.Feirantes.Any(feirante => feirante.ID == request.FeiranteID))
            {
                return BadRequest("Não existe nenhum feirante com id de " + request.FeiranteID);
            }
            if(!this._context.Feiras.Any(feira => feira.ID == request.FeiraID)) {
                return BadRequest("Não existe nenhuma feira com id de " + request.FeiraID);
            }

            if(this._context.StandsFeirantes.Any(stand => stand.FeiraID == id && stand.FeiranteID == request.FeiranteID))
            {
                return BadRequest("Este feirante já está ou estava(foi expulso ou saiu da feira) inscrito na feira");
            }

            var produtos = request.Produtos;

            var stand = new StandFeirante()
            {
                FeiranteID = request.FeiranteID,
                FeiraID = request.FeiraID,
            };

            foreach(var produtoID in produtos)
            {
                if(!this._context.Produtos.Any(produto => produtoID == produto.ID))
                {
                    return BadRequest("Não existe nenhum produto com id de " + produtoID);
                }

                var produtoStand = new ProdutoStand()
                {
                    ProdutoID = produtoID,
                    Preco = request.ProdutoPreco[produtoID],
                    Quantidade = request.QuantidadeProduto[produtoID],
                    Destacado = request.ProdutosDestacados.Contains(produtoID),
                };
                stand.ProdutosStands.Add(produtoStand);
            }

            await this._context.StandsFeirantes.AddAsync(stand);
            await this._context.SaveChangesAsync();
            return Ok(stand);

	    }

        [HttpGet]
        public ActionResult<List<Feira>> Get()
        {
            var compareDate = DateTime.Now;            

            return Ok(_context
                .Feiras
                // .Where(feira => feira.DataFim > compareDate)
                .Include(feira => feira.Stands)
                .Include(feira => feira.Categoria));
    	}

        [HttpGet("{id:int}")]
        public ActionResult<List<Feira>> GetFeira(int id) 
        {
            if(!this._context.Feiras.Any(feira => feira.ID == id)) 
            {
                Console.WriteLine("Procurando feira" + id);
                return NotFound();
            }

            Console.WriteLine("Procurando feira" + id);

            var feira = _context
                .Feiras
                .Where(feira => feira.ID == id)
                .Include(feira => feira.Categoria)
                .First();

            return Ok(feira);
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
                .Include(stand => stand.Vendas)
                .Include(stand => stand.Feirante)
                .ThenInclude(feirante => feirante.Conta)
                .Include(stand => stand.ProdutosStands.Where(produto => produto.Destacado))
                .ThenInclude(produtoStand => produtoStand.Produto)
                .ToList();

            return Ok(stands);
    	}

        [HttpGet("organizador/{organizadorID:int}")]
        public ActionResult<List<Feira>> GetFeiras(int organizadorID)
        {

            if(this._context.Feirantes.Any(feirante => feirante.ID == organizadorID))
            {
                return NotFound("Não existe nenhum feirante com o id passado");
            }

            return Ok(_context.Feiras.Where(feira => feira.FeiranteID == organizadorID)
            .Include(feira => feira.Organizador)
            .Include(feira => feira.Categoria)
            .ToList());
        }
    }
}

