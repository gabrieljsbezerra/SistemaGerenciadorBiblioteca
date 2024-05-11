using SistemaGerenciadorBiblioteca.Data;
using SistemaGerenciadorBiblioteca.Models;

namespace SistemaGerenciadorBiblioteca.Repositorio
{
    public class AlunosRepositorio : IAlunosRepositorio
    {
        //Injeção de dependência
        private readonly BancoContext _bancoContext; //variável privada
        public AlunosRepositorio(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }
        public AlunosModel ListarIdAluno(int id)
        {
            return _bancoContext.Alunos.FirstOrDefault(x => x.Id_aluno == id);
        }
        //Método que atualiza a view com tudo que está no banco de dados
        public List<AlunosModel> BuscarCadastroAluno()
        {
            return _bancoContext.Alunos.ToList();
        }
        //Método de Adicionar criado
        public AlunosModel Adicionar(AlunosModel alunos)
        {
            _bancoContext.Alunos.Add(alunos);
            _bancoContext.SaveChanges();

            return alunos;
        }
        public AlunosModel Atualizar(AlunosModel alunos)
        {
            AlunosModel alunoBD = ListarIdAluno(alunos.Id_aluno);

            if (alunoBD == null) throw new Exception("Erro ao salvar as alterações no Banco de Dados!! Null error.");

            alunoBD.Rm = alunos.Rm;
            alunoBD.Nome_Aluno = alunos.Nome_Aluno;
            alunoBD.Turma = alunos.Turma;
            alunoBD.Nome_Responsavel = alunos.Nome_Responsavel;
            alunoBD.Celular = alunos.Celular;
            alunoBD.Email = alunos.Email;

            _bancoContext.Alunos.Update(alunoBD);
            _bancoContext.SaveChanges();
            
            return alunoBD;
            
        }
    }
}
