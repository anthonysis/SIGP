using SIGP.Models;

namespace SIGP.Service
{
    public interface IEnderecoInterface
    {
        Task<ServiceResponse<List<EnderecoModel>>> GetEnderecos();
        Task<ServiceResponse<List<EnderecoModel>>> CreateEndereco(EnderecoModel novoEndereco);
        Task<ServiceResponse<EnderecoModel>> GetEnderecoById(int id);
        Task<ServiceResponse<List<EnderecoModel>>> UpdateEndereco(EnderecoModel editadoFuncionario);
        Task<ServiceResponse<List<EnderecoModel>>> DeleteEndereco(int id);
    }
}
