using SIGP.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGP.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }

        public int PessoaId { get; set; }
        [ForeignKey("PessoaId")]
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
            int pessoaId,
            string? cargo,
            DepartamentoEnum departamento,
            bool ativo,
            TurnoEnum turno,
            string? emailCorporativo,
            DateTime dataDeCriacao,
            DateTime dataDeAlteracao)
        {
            Id = id;
            PessoaId = pessoaId;
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
