using SistemaGerenciadorBiblioteca.Models;

namespace SistemaGerenciadorBiblioteca.Repositorio
{
    public interface IAlunosRepositorio
    {
        List<AlunosModel> BuscarCadastroAluno();
        AlunosModel Adicionar(AlunosModel alunos);
    }
}
