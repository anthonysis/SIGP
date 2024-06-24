using Microsoft.EntityFrameworkCore;
using SIGP.DataContext;
using SIGP.Models;

namespace SIGP.Service
{
    public class PessoaService : IPessoaInterface
    {
        private readonly ApplicationDbContext _context;
        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<PessoaModel>>> CreatePessoa(PessoaModel novoPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                if (novoPessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                novoPessoa.DataDeCriacao = DateTime.Now.ToLocalTime();
                novoPessoa.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Add(novoPessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoa.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> DeletePessoa(int id)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                PessoaModel pessoa = _context.Pessoa.FirstOrDefault(x => x.Id == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não localizada!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Pessoa.Remove(pessoa);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Pessoa.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PessoaModel>> GetPessoaById(int id)
        {
            ServiceResponse<PessoaModel> serviceResponse = new ServiceResponse<PessoaModel>();

            try
            {
                PessoaModel pessoa = _context.Pessoa.FirstOrDefault(x => x.Id == id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não localizada!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = pessoa;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> GetPessoas()
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {

                serviceResponse.Dados = _context.Pessoa.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }


            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PessoaModel>>> UpdatePessoa(PessoaModel editadoPessoa)
        {
            ServiceResponse<List<PessoaModel>> serviceResponse = new ServiceResponse<List<PessoaModel>>();

            try
            {
                PessoaModel pessoa = _context.Pessoa.AsNoTracking().FirstOrDefault(x => x.Id == editadoPessoa.Id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não localizada!";
                    serviceResponse.Sucesso = false;
                }


                pessoa.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Pessoa.Update(editadoPessoa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pessoa.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
