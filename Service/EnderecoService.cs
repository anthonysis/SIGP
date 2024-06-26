﻿using Microsoft.EntityFrameworkCore;
using SIGP.DataContext;
using SIGP.Models;

namespace SIGP.Service
{
    public class EnderecoService : IEnderecoInterface
    {
        private readonly ApplicationDbContext _context;
        public EnderecoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<EnderecoModel>>> CreateEndereco(EnderecoModel novoEndereco)
        {
            ServiceResponse<List<EnderecoModel>> serviceResponse = new ServiceResponse<List<EnderecoModel>>();

            try
            {
                if (novoEndereco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                novoEndereco.DataDeCriacao = DateTime.Now.ToLocalTime();
                novoEndereco.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Add(novoEndereco);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Endereco.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EnderecoModel>>> DeleteEndereco(int id)
        {
            ServiceResponse<List<EnderecoModel>> serviceResponse = new ServiceResponse<List<EnderecoModel>>();

            try
            {
                EnderecoModel endereco = _context.Endereco.FirstOrDefault(x => x.Id == id);

                if (endereco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Endereço não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Endereco.Remove(endereco);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Endereco.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EnderecoModel>> GetEnderecoById(int id)
        {
            ServiceResponse<EnderecoModel> serviceResponse = new ServiceResponse<EnderecoModel>();

            try
            {
                EnderecoModel endereco = _context.Endereco.FirstOrDefault(x => x.Id == id);

                if (endereco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
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

        public async Task<ServiceResponse<List<EnderecoModel>>> GetEnderecos()
        {
            ServiceResponse<List<EnderecoModel>> serviceResponse = new ServiceResponse<List<EnderecoModel>>();

            try
            {

                serviceResponse.Dados = _context.Endereco.ToList();

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

        public async Task<ServiceResponse<List<EnderecoModel>>> UpdateEndereco(EnderecoModel editadoEndereco)
        {
            ServiceResponse<List<EnderecoModel>> serviceResponse = new ServiceResponse<List<EnderecoModel>>();

            try
            {
                EnderecoModel endereco = _context.Endereco.AsNoTracking().FirstOrDefault(x => x.Id == editadoEndereco.Id);

                if (endereco == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }


                endereco.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Endereco.Update(editadoEndereco);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Endereco.ToList();

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
