using Microsoft.AspNetCore.Mvc;
using SIGP.Models;
using SIGP.Service;

namespace SIGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController
    {
        private readonly IEnderecoInterface _enderecoInterface;

        public EnderecoController(IEnderecoInterface enderecoInterface)
        {
            _enderecoInterface = enderecoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EnderecoModel>>>> GetEnderecos()
        {
            return await _enderecoInterface.GetEnderecos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EnderecoModel>>> GetEnderecoById(int id)
        {
            return await _enderecoInterface.GetEnderecoById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EnderecoModel>>>> CreateEndereco(EnderecoModel novoEndereco)
        {
            return await _enderecoInterface.CreateEndereco(novoEndereco);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<EnderecoModel>>>> UpdateEndereco(EnderecoModel editadoEndereco)
        {
            ServiceResponse<List<EnderecoModel>> serviceResponse = await _enderecoInterface.UpdateEndereco(editadoEndereco);

            return serviceResponse;
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<EnderecoModel>>>> DeleteEndereco(int id)
        {
            ServiceResponse<List<EnderecoModel>> serviceResponse = await _enderecoInterface.DeleteEndereco(id);

            return serviceResponse;

        }
    }
}
