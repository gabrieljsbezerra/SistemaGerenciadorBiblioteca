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

        public ActionResult Editar_aluno(int id)
        {
            AlunosModel info = _alunosRepositorio.ListarIdAluno(id);
            return View(info);
        }

        public ActionResult Deletar_aluno(int id)
        {
            AlunosModel info = _alunosRepositorio.ListarIdAluno(id);
            return View(info);
        }
        public ActionResult Delete(int id)
        {
            _alunosRepositorio.Deletar(id);
            return RedirectToAction("Index");
        }
        //Posters - Responsável por armazenar e gravar as informações
        [HttpPost]
        public ActionResult Adicionar_aluno(AlunosModel alunos)
        {
            if (ModelState.IsValid)
            {
                _alunosRepositorio.Adicionar(alunos);
                return RedirectToAction("Index");
            }
            else { return View(alunos); }
        }
        [HttpPost]
        public ActionResult Editar_aluno(AlunosModel alunos)
        {
            if (ModelState.IsValid)
            {
                _alunosRepositorio.Atualizar(alunos);
                return RedirectToAction("Index");
            }
            else
            {
                return View(alunos);
            }
        }
    }
}
