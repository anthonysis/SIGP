using Microsoft.EntityFrameworkCore;
using SIGP.DataContext;
using SIGP.Models;

namespace SIGP.Service
{
    public class TelefoneService : ITelefoneInterface
    {
        private readonly ApplicationDbContext _context;
        public TelefoneService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<TelefoneModel>>> CreateTelefone(TelefoneModel novoTelefone)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = new ServiceResponse<List<TelefoneModel>>();

            try
            {
                if (novoTelefone == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                novoTelefone.DataDeCriacao = DateTime.Now.ToLocalTime();
                novoTelefone.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Add(novoTelefone);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Telefone.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TelefoneModel>>> DeleteTelefone(int id)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = new ServiceResponse<List<TelefoneModel>>();

            try
            {
                TelefoneModel endereco = _context.Telefone.FirstOrDefault(x => x.Id == id);

                if (endereco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Telefone não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Telefone.Remove(endereco);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Telefone.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<TelefoneModel>> GetTelefoneById(int id)
        {
            ServiceResponse<TelefoneModel> serviceResponse = new ServiceResponse<TelefoneModel>();

            try
            {
                TelefoneModel endereco = _context.Telefone.FirstOrDefault(x => x.Id == id);

                if (endereco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Telefone não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = endereco;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TelefoneModel>>> GetTelefones()
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = new ServiceResponse<List<TelefoneModel>>();

            try
            {

                serviceResponse.Dados = _context.Telefone.ToList();

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

        public async Task<ServiceResponse<List<TelefoneModel>>> UpdateTelefone(TelefoneModel editadoTelefone)
        {
            ServiceResponse<List<TelefoneModel>> serviceResponse = new ServiceResponse<List<TelefoneModel>>();

            try
            {
                TelefoneModel telefone = _context.Telefone.AsNoTracking().FirstOrDefault(x => x.Id == editadoTelefone.Id);

                if (telefone == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Telefone não localizado!";
                    serviceResponse.Sucesso = false;
                }


                telefone.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Telefone.Update(editadoTelefone);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Telefone.ToList();

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
