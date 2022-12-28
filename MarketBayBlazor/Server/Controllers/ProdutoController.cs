using Microsoft.AspNetCore.Mvc;

namespace MarketBayBlazor.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController: ControllerBase
{

    private readonly DatabaseContext _context;

    public ProdutoController(DatabaseContext _context)
    {
        this._context = _context; 
    }

    [HttpGet("{categoriaID:int}")]
    public async Task<ActionResult<List<Produto>>> Get(int categoriaID)
    {
        if(!this._context.Categorias.Any(categoria => categoria.ID == categoriaID))
        {
            return BadRequest("Não existem categorias com o id passado " + categoriaID);
        }

        var produtos = await this._context
            .Produtos
            .Where(produto => produto.CategoriaID == categoriaID)
            .Include(p => p.Categoria)
            .ToListAsync();

        Console.WriteLine(produtos.ToString());

        return Ok(produtos);
    }

}