using Microsoft.AspNetCore.Mvc;
using SistemaGerenciadorBiblioteca.Models;
using SistemaGerenciadorBiblioteca.Repositorio;

namespace SistemaGerenciadorBiblioteca.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunosRepositorio _alunosRepositorio;
        public AlunosController(IAlunosRepositorio alunosRepositorio) 
        {
            _alunosRepositorio = alunosRepositorio;
        }
        public IActionResult Index()
        {
            List<AlunosModel> alunos = _alunosRepositorio.BuscarCadastroAluno(); //Busca no banco de dados
            return View(alunos); //retorna para a view
        }

        public ActionResult Adicionar_aluno()
        {
            return View();
        }

        public ActionResult Editar_aluno()
        {
            return View();
        }

        public ActionResult Deletar_aluno()
        {
            return View();
        }

        //Posters - Responsável por armazenar e gravar as informações
        public ActionResult Create(AlunosModel alunos)
        {
            _alunosRepositorio.Adicionar(alunos);
            return RedirectToAction("Index");
        }
    }
}
