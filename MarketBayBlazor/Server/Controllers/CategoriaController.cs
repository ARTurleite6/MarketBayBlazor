using Microsoft.AspNetCore.Mvc;

namespace MarketBayBlazor.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : Controller
{

    private readonly DatabaseContext _context;

    public CategoriaController(DatabaseContext _context)
    {
        this._context = _context;
    } 

    [HttpGet]
    public ActionResult<List<Categoria>> GetCategorias()
    {
        return Ok(this._context.Categorias.ToList());
    }
}