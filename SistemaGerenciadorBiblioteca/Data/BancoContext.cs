using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorBiblioteca.Models;

namespace SistemaGerenciadorBiblioteca.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<LivrosModel> Livros { get; set; }
        public DbSet<AlunosModel> Alunos { get; set; }
        public DbSet<EmprestimosModel> Emprestimos { get; set; }

    }
}
