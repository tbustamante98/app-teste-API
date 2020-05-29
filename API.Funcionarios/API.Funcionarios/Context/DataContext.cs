using API.Funcionarios.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Funcionarios.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<FuncionarioHabilidades> FuncionarioHabilidades { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habilidade>()
                .HasData(new Habilidade[]
                {
                    new Habilidade{Id= 1, Nome = "C#"},
                    new Habilidade{Id= 2, Nome = "Java"},
                    new Habilidade{Id= 3, Nome = "Angular"},
                    new Habilidade{Id= 4, Nome = "SQL"},
                    new Habilidade{Id= 5, Nome = "ASP"}
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
