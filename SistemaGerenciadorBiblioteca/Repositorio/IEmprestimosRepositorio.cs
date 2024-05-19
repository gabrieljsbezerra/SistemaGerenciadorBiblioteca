using SistemaGerenciadorBiblioteca.Models;

namespace SistemaGerenciadorBiblioteca.Repositorio
{
    public interface IEmprestimosRepositorio
    {
        EmprestimosModel ListarIdEmprestimo(int Id_emprestimo);
        List<EmprestimosModel> BuscarCadastroEmprestimo();
        EmprestimosModel Adicionar(EmprestimosModel emprestimos);
        EmprestimosModel Atualizar(EmprestimosModel emprestimos);
        bool Deletar(int id);
    }
}
