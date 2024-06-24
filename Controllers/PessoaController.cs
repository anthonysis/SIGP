using Microsoft.AspNetCore.Mvc;
using SIGP.Models;
using SIGP.Service;

namespace SIGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController
    {
        private readonly IPessoaInterface _pessoaInterface;

        public PessoaController(IPessoaInterface pessoaInterface)
        {
            _pessoaInterface = pessoaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> GetPessoas()
        {
            return await _pessoaInterface.GetPessoas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PessoaModel>>> GetPessoaById(int id)
        {
            return await _pessoaInterface.GetPessoaById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> CreatePessoa(PessoaModel novoPessoa)
        {
            return await _pessoaInterface.CreatePessoa(novoPessoa);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> UpdatePessoa(PessoaModel editadoPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = await _pessoaInterface.UpdatePessoa(editadoPessoa);

            return serviceResponse;
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<PessoaModel>>>> DeletePessoa(int id)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = await _pessoaInterface.DeletePessoa(id);

            return serviceResponse;

        }
    }
}
