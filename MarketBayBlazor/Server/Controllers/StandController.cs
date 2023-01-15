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

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, StandFeirante newStand)
        {
            
            if(!this._context.StandsFeirantes.Any(stand => stand.ID == id))
            {
                return BadRequest("Não existe nenhum feirante com o id passado");
            }

            this._context.Update(newStand);
            await this._context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("reservaproduto/{standid:int}/{produtoid:int}/{quantidade:int}")]
        public async Task<ActionResult> ReservaProduto(int standid, int produtoid, int quantidade)
        {
            if(!this._context.StandsFeirantes.Any(stand => stand.ID == standid))
            {
                return BadRequest("Não existe nenhum stand com este id");
            }
            var produto = this._context.ProdutosStands.Where(produtoStand => produtoStand.StandFeiranteID == standid).First(produtoStand => produtoStand.ProdutoID == produtoid);
            if(produto == null)
            {
                return BadRequest("Este feirante não comercializa este produto");
            }
            if(produto.Quantidade - quantidade < 0)
            {
                return BadRequest("O feirante não possui esta quantidade em stock");
            } 

            produto.Quantidade -= quantidade;
            Console.Write(quantidade);
            Console.WriteLine(produto.Quantidade);
            try {
                this._context.SaveChanges();
                return Ok();
            } catch(DbUpdateException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("adicionaproduto/{standid:int}/{produtoid:int}/{quantidade:int}")]
        public async Task<ActionResult> AdicionaAoProduto(int standid, int produtoid, int quantidade)
        {
            if(!this._context.StandsFeirantes.Any(stand => stand.ID == standid))
            {
                return BadRequest("Não existe nenhum stand com este id");
            }
            var produto = this._context.ProdutosStands.Where(produtoStand => produtoStand.StandFeiranteID == standid).First(produtoStand => produtoStand.ProdutoID == produtoid);
            if(produto == null)
            {
                return BadRequest("Este feirante não comercializa este produto");
            }

            produto.Quantidade += quantidade;
            try {
                await this._context.SaveChangesAsync();
                return Ok();
            } catch(DbUpdateException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("updateproduto/{produtoid:int}")]
        public async Task<ActionResult> UpdateProduto(int produtoID, ProdutoStand produto)
        {
            this._context.ProdutosStands.Update(produto);
            try {
                await this._context.SaveChangesAsync();
                return Ok();
            } catch(DbUpdateException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

