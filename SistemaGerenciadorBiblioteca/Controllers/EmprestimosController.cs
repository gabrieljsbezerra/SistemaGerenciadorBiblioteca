using Microsoft.AspNetCore.Mvc;

namespace SistemaGerenciadorBiblioteca.Controllers
{
    public class EmprestimosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
