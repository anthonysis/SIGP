using System.ComponentModel.DataAnnotations;

namespace EventosAPI.Entities
{
    public class Pessoa
    {
        public Pessoa()
        {
            Nome = "";
            Rg = "";
            Cpf = "";
            IsDeleted = false;
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set;}

        public DateTime DataDeNascimento { get; set;}

        public bool IsDeleted { get; set; }

        public void Update(string nome, string rg, string cpf, DateTime dataDeNascimento)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
