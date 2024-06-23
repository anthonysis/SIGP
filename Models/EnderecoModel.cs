using System.ComponentModel.DataAnnotations;

namespace SIGP.Models
{
    public class EnderecoModel
    {
        [Key]
        public int Id { get; set; }

        public string? Cep { get; set; }

        public string? Logradouro { get; set; }

        public int Numero { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Estado { get; set; }

        public string? Cidade { get; set; }

        public string? Pais { get; set; }

        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    }
}
