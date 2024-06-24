using Microsoft.EntityFrameworkCore;
using SIGP.DataContext;
using SIGP.Models;

namespace SIGP.Service
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                novoFuncionario.DataDeCriacao = DateTime.Now.ToLocalTime();
                novoFuncionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Funcionario
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Endereco)
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Telefone)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = await _context.Funcionario
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Endereco)
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Telefone)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Funcionario.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Funcionario
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Endereco)
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Telefone)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = await _context.Funcionario
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Endereco)
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Telefone)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não localizado!";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = funcionario;
                    serviceResponse.Sucesso = true;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = await _context.Funcionario
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Endereco)
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Telefone)
                    .ToListAsync();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
                else
                {
                    serviceResponse.Sucesso = true;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = await _context.Funcionario
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Endereco)
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Telefone)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    funcionario.Ativo = false;
                    funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                    _context.Funcionario.Update(funcionario);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Funcionario
                        .Include(f => f.Pessoa)
                            .ThenInclude(p => p.Endereco)
                        .Include(f => f.Pessoa)
                            .ThenInclude(p => p.Telefone)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = await _context.Funcionario
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Endereco)
                    .Include(f => f.Pessoa)
                        .ThenInclude(p => p.Telefone)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == editadoFuncionario.Id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    editadoFuncionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                    _context.Funcionario.Update(editadoFuncionario);
                    await _context.SaveChangesAsync();

                    serviceResponse.Dados = await _context.Funcionario
                        .Include(f => f.Pessoa)
                            .ThenInclude(p => p.Endereco)
                        .Include(f => f.Pessoa)
                            .ThenInclude(p => p.Telefone)
                        .ToListAsync();
                }
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