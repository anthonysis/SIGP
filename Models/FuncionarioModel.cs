using SIGP.Enums;
using System.ComponentModel.DataAnnotations;

namespace SIGP.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public PessoaModel Pessoa { get; set; }
        public string? Cargo { get; set; }
        public DepartamentoEnum Departamento { get; set; }
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public string? EmailCorporativo { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();

        public FuncionarioModel() { }

        public FuncionarioModel(
            int id, 
            PessoaModel pessoa, 
            string? cargo, 
            DepartamentoEnum departamento, 
            bool ativo, 
            TurnoEnum turno, 
            string? emailCorporativo, 
            DateTime dataDeCriacao, 
            DateTime dataDeAlteracao)
        {
            Id = id;
            Pessoa = pessoa;
            Cargo = cargo;
            Departamento = departamento;
            Ativo = ativo;
            Turno = turno;
            EmailCorporativo = emailCorporativo;
            DataDeCriacao = dataDeCriacao;
            DataDeAlteracao = dataDeAlteracao;
        }
    }
}
