using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorBiblioteca.Data;
using SistemaGerenciadorBiblioteca.Models;
using SistemaGerenciadorBiblioteca.Repositorio;

namespace SistemaGerenciadorBiblioteca.Controllers
{
    public class EmprestimosController : Controller
    {

        private readonly IEmprestimosRepositorio _emprestimosRepositorio;
        private readonly BancoContext _context;

        public EmprestimosController(IEmprestimosRepositorio emprestimosRepositorio, BancoContext context)
        {
            _emprestimosRepositorio = emprestimosRepositorio;
            _context = context;
        }
        public IActionResult Index()
        {
            List<EmprestimosModel> emprestimos = _emprestimosRepositorio.BuscarCadastroEmprestimo();
            return View(emprestimos);
        }
        public ActionResult Adicionar_Emprestimo()
        {
            ViewBag.Livros = new SelectList(_context.Livros, "Id_livro", "Titulo");
            ViewBag.Alunos = new SelectList(_context.Alunos, "Id_aluno", "Nome_Aluno");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar_Emprestimo(EmprestimosModel emprestimos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _emprestimosRepositorio.Adicionar(emprestimos);
                    TempData["MensagemSucesso"] = "Empréstimo cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemPreencha"] = "Preencha os campos faltantes!!";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                    ViewBag.Livros = new SelectList(_context.Livros, "Id_livro", "Titulo", emprestimos.Id_livro);
                    ViewBag.Alunos = new SelectList(_context.Alunos, "Id_aluno", "Nome_Aluno", emprestimos.Id_aluno);
                    return View(emprestimos);
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar o novo empréstimo. Tente novamente! Detalhe do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
