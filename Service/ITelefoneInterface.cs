using SIGP.Models;

namespace SIGP.Service
{
    public interface ITelefoneInterface
    {
        Task<ServiceResponse<List<TelefoneModel>>> GetTelefones();
        Task<ServiceResponse<List<TelefoneModel>>> CreateTelefone(TelefoneModel telefone);
        Task<ServiceResponse<TelefoneModel>> GetTelefoneById(int id);
        Task<ServiceResponse<List<TelefoneModel>>> UpdateTelefone(TelefoneModel telefone);
        Task<ServiceResponse<List<TelefoneModel>>> DeleteTelefone(int id);
    }
}
