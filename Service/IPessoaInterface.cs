using SIGP.Models;

namespace SIGP.Service
{
    public interface IPessoaInterface
    {
        Task<ServiceResponse<List<PessoaModel>>> GetPessoas();
        Task<ServiceResponse<List<PessoaModel>>> CreatePessoa(PessoaModel pessoa);
        Task<ServiceResponse<PessoaModel>> GetPessoaById(int id);
        Task<ServiceResponse<List<PessoaModel>>> UpdatePessoa(PessoaModel pessoa);
        Task<ServiceResponse<List<PessoaModel>>> DeletePessoa(int id);
    }
}
