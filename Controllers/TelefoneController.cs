using Microsoft.AspNetCore.Mvc;
using SIGP.Models;
using SIGP.Service;

namespace SIGP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController
    {
        private readonly ITelefoneInterface _telefoneInterface;

        public TelefoneController(ITelefoneInterface telefoneInterface)
        {
            _telefoneInterface = telefoneInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TelefoneModel>>>> GetTelefones()
        {
            return await _telefoneInterface.GetTelefones();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TelefoneModel>>> GetTelefoneById(int id)
        {
            return await _telefoneInterface.GetTelefoneById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TelefoneModel>>>> CreateTelefone(TelefoneModel novoTelefone)
        {
            return await _telefoneInterface.CreateTelefone(novoTelefone);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<TelefoneModel>>>> UpdateTelefone(TelefoneModel editadoTelefone)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = await _telefoneInterface.UpdateTelefone(editadoTelefone);

            return serviceResponse;
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<TelefoneModel>>>> DeleteTelefone(int id)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = await _telefoneInterface.DeleteTelefone(id);

            return serviceResponse;

        }
    }
}
