using SIGP.Enums;
using System.ComponentModel.DataAnnotations;

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

        public EnderecoModel Endereco { get; set; }

        public TelefoneModel Telefone { get; set; }

        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();

        public PessoaModel(int id, string nome, string? sobrenome, string? cpf, string? rg, string? cnh, DateTime dataDeNascimento, GeneroEnum genero, EstadoCivilEnum estadoCivil, string estadoDeOrigem, string? cidadeDeOrigem, EnderecoModel endereco, TelefoneModel telefone, DateTime dataDeCriacao, DateTime dataDeAlteracao)
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
            Endereco = endereco;
            Telefone = telefone;
            DataDeCriacao = dataDeCriacao;
            DataDeAlteracao = dataDeAlteracao;
        }

        public PessoaModel()
        {
        }
    }
}
