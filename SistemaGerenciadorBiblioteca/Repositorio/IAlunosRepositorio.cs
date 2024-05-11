using SistemaGerenciadorBiblioteca.Models;

namespace SistemaGerenciadorBiblioteca.Repositorio
{
    public interface IAlunosRepositorio
    {
        AlunosModel ListarIdAluno(int Id_aluno);
        List<AlunosModel> BuscarCadastroAluno();
        AlunosModel Adicionar(AlunosModel alunos);
        AlunosModel Atualizar(AlunosModel alunos);
    }
}
