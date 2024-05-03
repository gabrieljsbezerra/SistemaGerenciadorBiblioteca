using Microsoft.AspNetCore.Mvc;

namespace SistemaGerenciadorBiblioteca.Controllers
{
    public class AlunosController : Controller
    {
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
    }
}
