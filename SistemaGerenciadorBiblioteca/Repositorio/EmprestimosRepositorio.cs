using SistemaGerenciadorBiblioteca.Data;
using SistemaGerenciadorBiblioteca.Models;

namespace SistemaGerenciadorBiblioteca.Repositorio
{
    public class EmprestimosRepositorio : IEmprestimosRepositorio
    {
        //Injeção de dependência
        private readonly BancoContext _bancoContext; //variável privada
        public EmprestimosRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }
        public EmprestimosModel ListarIdEmprestimo(int id)
        {
            return _bancoContext.EmprestimosModel.FirstOrDefault(x => x.Id_emprestimo == id);
        }
        //Método que atualiza a view com tudo que está no banco de dados
        public List<EmprestimosModel> BuscarCadastroEmprestimo()
        {
            return _bancoContext.EmprestimosModel.ToList();
        }
        //Método de Adicionar criado
        public EmprestimosModel Adicionar(EmprestimosModel emprestimos)
        {
            _bancoContext.EmprestimosModel.Add(emprestimos);
            _bancoContext.SaveChanges();

            return emprestimos;
        }
        public EmprestimosModel Atualizar(EmprestimosModel emprestimos)
        {
            EmprestimosModel emprestimoBD = ListarIdEmprestimo(emprestimos.Id_emprestimo);

            if (emprestimoBD == null) throw new Exception("Erro ao salvar as alterações no Banco de Dados!! Null error.");

            emprestimoBD.Data_Emprestimo = emprestimos.Data_Emprestimo;
            emprestimoBD.Data_Devolucao = emprestimos.Data_Devolucao;
            emprestimoBD.Id_aluno = emprestimos.Id_aluno;
            emprestimoBD.Id_livro = emprestimos.Id_livro;

            _bancoContext.EmprestimosModel.Update(emprestimoBD);
            _bancoContext.SaveChanges();

            return emprestimoBD;

        }

        public bool Deletar(int id)
        {
            EmprestimosModel emprestimoBD = ListarIdEmprestimo(id);

            if (emprestimoBD == null) throw new Exception("Erro ao Deletar no Banco de Dados!! Null error.");

            _bancoContext.EmprestimosModel.Remove(emprestimoBD);
            _bancoContext.SaveChanges();
            return true;
        }

    }
}
