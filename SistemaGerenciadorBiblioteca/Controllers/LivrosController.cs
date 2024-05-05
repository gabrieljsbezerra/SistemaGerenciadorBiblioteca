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
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
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
