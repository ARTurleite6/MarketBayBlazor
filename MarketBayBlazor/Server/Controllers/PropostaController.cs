using Microsoft.AspNetCore.Mvc;

namespace MarketBayBlazor.Server
{
    [Route("[controller]")]
    [ApiController]
    public class PropostaController : Controller
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
            } catch(DbUpdateException exc) {
                return BadRequest("Erro na inserção da proposta");
            }

            return Ok();
        }

    }
}