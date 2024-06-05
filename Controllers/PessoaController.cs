using EventosAPI.Entities;
using EventosAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIGP.Controllers
{
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoasDbContext _context;
        public PessoaController(PessoasDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pessoas = _context.Pessoas.Where(d => !d.IsDeleted).ToList();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var pessoa = _context.Pessoas.SingleOrDefault(d => d.Id == id);

            if (pessoa == null)
            {
                return NotFound(new { message = "Pessoa não encontrada" });
            }

            return Ok(pessoa);
        }

        [HttpPost]
        public IActionResult Post(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
        }

        [HttpPut]
        public IActionResult Update(Guid id, Pessoa pessoa)
        {
            var pessoaAlt = _context.Pessoas.Single(d => d.Id == id);

            if (pessoaAlt == null)
            {
                return NotFound();
            }

            pessoaAlt.Update(pessoa.Nome, pessoa.Rg, pessoa.Cpf, pessoa.DataDeNascimento);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var events = _context.Pessoas.SingleOrDefault(d => d.Id == id);

            if (events == null)
            {
                return NotFound();
            }

            events.Delete();

            return NoContent();
        }

    }
}
