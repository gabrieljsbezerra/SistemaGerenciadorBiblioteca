using SistemaGerenciadorBiblioteca.Models;

namespace SistemaGerenciadorBiblioteca.Repositorio
{
    public interface ILivrosRepositorio
    {
        List<LivrosModel> BuscarCadastroLivro();
        LivrosModel Adicionar(LivrosModel livros);
    }
}
