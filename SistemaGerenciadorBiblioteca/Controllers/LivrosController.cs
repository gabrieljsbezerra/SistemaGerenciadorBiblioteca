using Microsoft.AspNetCore.Mvc;
using SistemaGerenciadorBiblioteca.Data;
using SistemaGerenciadorBiblioteca.Models;
using SistemaGerenciadorBiblioteca.Repositorio;

namespace SistemaGerenciadorBiblioteca.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ILivrosRepositorio _livrosRepositorio; //variável privada
        public LivrosController(ILivrosRepositorio livrosRepositorio) //Construtor da Classe com a injeção de dependência
        {
            _livrosRepositorio = livrosRepositorio;
        }

        //Getters - Apenas mostra as informações
        public IActionResult Index()
        {
            List<LivrosModel> livros = _livrosRepositorio.BuscarCadastroLivro(); //Busca no banco de dados
            return View(livros); //retorna para a view
        }

        public ActionResult Adicionar_livro()
        {
            return View();
        }

        public ActionResult Editar_livro(int id)
        {
            LivrosModel info = _livrosRepositorio.ListarporIdLivro(id);
            return View(info);
        }

        public ActionResult Deletar_livro()
        {
            return View();
        }

        //Posters - Responsável por armazenar e gravar as informações
        [HttpPost]
        public ActionResult Create(LivrosModel livros)
        {
            _livrosRepositorio.Adicionar(livros);
            return RedirectToAction("Index");
        }
    }
}
