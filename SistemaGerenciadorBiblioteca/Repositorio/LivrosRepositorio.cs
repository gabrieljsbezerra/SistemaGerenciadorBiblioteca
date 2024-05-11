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
        public LivrosModel ListarporIdLivro(int id)
        {
            return _bancoContext.Livros.FirstOrDefault(x => x.Id_livro == id);
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
        public LivrosModel Atualizar(LivrosModel livros)
        {
            LivrosModel livrosBD = ListarporIdLivro(livros.Id_livro);

            if (livrosBD == null) throw new Exception("Erro ao salvar as alterações no Banco de Dados!! Null error.");

            livrosBD.Titulo = livros.Titulo;
            livrosBD.Autor = livros.Autor;
            livrosBD.Genero = livros.Genero;
            livrosBD.Editora = livros.Editora;
            livrosBD.Ano = livros.Ano;

            _bancoContext.Livros.Update(livrosBD);
            _bancoContext.SaveChanges();

            return livrosBD;
        }

        public bool Deletar(int id)
        {
            LivrosModel livrosBD = ListarporIdLivro(id);

            if (livrosBD == null) throw new Exception("Erro ao Deletar no Banco de Dados!! Null error.");

            _bancoContext.Livros.Remove(livrosBD);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
