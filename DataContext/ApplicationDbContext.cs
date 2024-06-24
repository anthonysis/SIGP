using Microsoft.EntityFrameworkCore;
using SIGP.Models;
using System.Collections.Generic;

namespace SIGP.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<FuncionarioModel> Funcionario { get; set; }

        public DbSet<EnderecoModel> Endereco { get; set; }

        public DbSet<TelefoneModel> Telefone { get; set; }

        public DbSet<PessoaModel> Pessoa { get; set; }
    }
}

