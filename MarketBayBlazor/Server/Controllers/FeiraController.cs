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

        [HttpGet]
        public ActionResult<List<Feira>> Get()
        {
            return Ok(_context
                .Feiras
                .Include(feira => feira.Categoria));
    	}

        [HttpGet("stands/{id}")]
        public ActionResult<List<StandFeirante>> GetStands(int id)
        {
            var stands = _context
                .StandsFeirantes
                .Where(stand => stand.FeiraID == id)
                .Include(stand => stand.Feirante)
                .Include(stand => stand.ProdutosStands)
                .ToList();

            return Ok(stands);
    	}
    }
}

