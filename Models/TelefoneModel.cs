using System.ComponentModel.DataAnnotations;

namespace SIGP.Models
{
    public class TelefoneModel
    {
        [Key]
        public int Id { get; set; }

        public int CodigoDeArea { get; set; }

        public string? Numero { get; set; }

        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
