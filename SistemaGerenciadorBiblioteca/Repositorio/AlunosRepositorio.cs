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
            _bancoContext = bancoContext;
        }
        //Método de Adicionar criado
        public AlunosModel Adicionar(AlunosModel alunos)
        {
            _bancoContext.Alunos.Add(alunos);
            _bancoContext.SaveChanges();

            return alunos;
        }
    }
}
