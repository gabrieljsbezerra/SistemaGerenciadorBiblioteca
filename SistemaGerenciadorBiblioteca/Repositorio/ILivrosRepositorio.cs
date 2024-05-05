using SistemaGerenciadorBiblioteca.Models;

namespace SistemaGerenciadorBiblioteca.Repositorio
{
    public interface ILivrosRepositorio
    {
        LivrosModel Adicionar(LivrosModel livros);
    }
}
