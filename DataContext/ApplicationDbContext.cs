using Microsoft.EntityFrameworkCore;
using SIGP.Models;
using System.Collections.Generic;

namespace SIGP.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<FuncionarioModel> Funcionarios { get; set; }

        public DbSet<EnderecoModel> Enderecos { get; set; }
    }
}

