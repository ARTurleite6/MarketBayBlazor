using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterFeirante(FeiranteDTO request)
        {

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var feirante = new Feirante()
            {
                NIFempresarial = request.NIFempresarial,
                Foto = request.Foto ?? "Não tem foto",
                Conta = new Conta()
                {
                    Nome = request.Nome,
                    Morada = new Morada()
                    {
                        Rua = request.Rua,
                        CodigoPostal = request.CodigoPostal,
                        Localidade = request.Localidade,
                    },
                    Email = request.Email,
                    Password = passwordHash,
                    PasswordSalt = passwordSalt,
                    NumeroTelemovel = request.NumeroTelemovel,
                },
            };

            await this._context.Feirantes.AddAsync(feirante);
            try {
                await this._context.SaveChangesAsync();
            } catch(DbUpdateException)
            {
                Console.WriteLine("Erro a inserir Feirante " + request.Email);
                return BadRequest("Error creating Feirante");
            }

            return Ok();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

