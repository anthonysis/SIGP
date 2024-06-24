using SIGP.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGP.Models
{
    public class PessoaModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? Sobrenome { get; set; }

        public string? Cpf { get; set; }

        public string? Rg { get; set; }

        public string? Cnh { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public GeneroEnum Genero { get; set; }

        public EstadoCivilEnum EstadoCivil { get; set; }

        public string EstadoDeOrigem { get; set; }

        public string? CidadeDeOrigem { get; set; }

        public int EnderecoId { get; set; }
        [ForeignKey("EnderecoId")]
        public EnderecoModel Endereco { get; set; }

        public int TelefoneId { get; set; }
        [ForeignKey("TelefoneId")]
        public TelefoneModel Telefone { get; set; }

        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();

        public PessoaModel(int id, string nome, string? sobrenome, string? cpf, string? rg, string? cnh, DateTime dataDeNascimento, GeneroEnum genero, EstadoCivilEnum estadoCivil, string estadoDeOrigem, string? cidadeDeOrigem, int enderecoId, EnderecoModel endereco, int telefoneId, TelefoneModel telefone, DateTime dataDeCriacao, DateTime dataDeAlteracao)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Rg = rg;
            Cnh = cnh;
            DataDeNascimento = dataDeNascimento;
            Genero = genero;
            EstadoCivil = estadoCivil;
            EstadoDeOrigem = estadoDeOrigem;
            CidadeDeOrigem = cidadeDeOrigem;
            EnderecoId = enderecoId;
            Endereco = endereco;
            TelefoneId = telefoneId;
            Telefone = telefone;
            DataDeCriacao = dataDeCriacao;
            DataDeAlteracao = dataDeAlteracao;
        }

        public PessoaModel()
        {
        }
    }
}
