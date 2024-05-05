using SistemaGerenciadorBiblioteca.Data;
using SistemaGerenciadorBiblioteca.Models;

namespace SistemaGerenciadorBiblioteca.Repositorio
{
    public class LivrosRepositorio : ILivrosRepositorio
    {
        //Injeção de dependência
        private readonly BancoContext _bancoContext; //variável privada
        public LivrosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        //Método que atualiza a view com tudo que está no banco de dados
        public List<LivrosModel> BuscarCadastroLivro()
        {
            return _bancoContext.Livros.ToList();
        }
        //Método de Adicionar criado
        public LivrosModel Adicionar(LivrosModel livros)
        {
            _bancoContext.Livros.Add(livros);
            _bancoContext.SaveChanges();

            return livros;
        }
    }
}
