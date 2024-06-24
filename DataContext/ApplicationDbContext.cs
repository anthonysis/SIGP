using Microsoft.EntityFrameworkCore;
using SIGP.Models;

namespace SIGP.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<FuncionarioModel> Funcionario { get; set; }

        public DbSet<EnderecoModel> Endereco { get; set; }

        public DbSet<TelefoneModel> Telefone { get; set; }

        public DbSet<PessoaModel> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da relação entre PessoaModel e EnderecoModel
            modelBuilder.Entity<PessoaModel>()
                .HasOne(p => p.Endereco)
                .WithOne()
                .HasForeignKey<PessoaModel>(p => p.EnderecoId);

            // Configuração da relação entre PessoaModel e TelefoneModel
            modelBuilder.Entity<PessoaModel>()
                .HasOne(p => p.Telefone)
                .WithOne()
                .HasForeignKey<PessoaModel>(p => p.TelefoneId);

            modelBuilder.Entity<FuncionarioModel>()
           .HasOne(f => f.Pessoa)
           .WithMany()
           .HasForeignKey(f => f.PessoaId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
