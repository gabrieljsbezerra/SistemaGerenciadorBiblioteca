using Microsoft.AspNetCore.Mvc;
using SistemaGerenciadorBiblioteca.Models;
using SistemaGerenciadorBiblioteca.Repositorio;

namespace SistemaGerenciadorBiblioteca.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly IEmprestimosRepositorio _emprestimosRepositorio;
        public EmprestimosController(IEmprestimosRepositorio emprestimosRepositorio)
        {
            _emprestimosRepositorio = emprestimosRepositorio;
        }
        public IActionResult Index()
        {
            List<EmprestimosModel> emprestimos = _emprestimosRepositorio.BuscarCadastroEmprestimo();
            return View(emprestimos);
        }
    }
}
