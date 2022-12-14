using Microsoft.AspNetCore.Mvc;

namespace MarketBayBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaController : ControllerBase
    {

        private readonly DatabaseContext _context;

        public PropostaController(DatabaseContext _context)
        {
            this._context = _context;
        }


        [HttpPost]
        public async Task<ActionResult> SendProposta(Proposta proposta)
        {
            if(!this._context.Clientes.Any(cliente => cliente.ID == proposta.ClienteID))
            {
                return BadRequest("Não existe o cliente passado");
            }
            if(!this._context.StandsFeirantes.Any(stand => stand.ID == proposta.StandFeiranteID))
            {
                return BadRequest("Não existe o stand passado");
            }
            if(!this._context.Produtos.Any(produto => produto.ID == proposta.ProdutoID))
            {
                return BadRequest("Não existe o produto passado");
            }


            await this._context.Propostas.AddAsync(proposta);
            try {
                await this._context.SaveChangesAsync();
            } catch (DbUpdateException)
            {
                return BadRequest("Erro na inserção da proposta");
            }

            return Ok();
        }

        [HttpGet("{standID:int}")]
        public async Task<ActionResult<List<Proposta>>> GetPropostasStand(int standID)
        {
            if(!this._context.StandsFeirantes.Any(stand => stand.ID == standID))
            {
                return NotFound("Could not found a stand with id = " + standID);
            }

            return Ok(await this._context.Propostas
            .Where(proposta => proposta.StandFeiranteID == standID)
            .OrderByDescending(proposta => proposta.data)
            .Include(proposta => proposta.Produto)
            .ThenInclude(produto => produto.Categoria)
            .Include(proposta => proposta.Cliente)
            .ThenInclude(cliente => cliente.Conta)
            .ToListAsync<Proposta>());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProposta(int id, Proposta proposta)
        {
            this._context.Propostas.Update(proposta);
            try {
                await this._context.SaveChangesAsync();
            } catch(DbUpdateException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

    }
}