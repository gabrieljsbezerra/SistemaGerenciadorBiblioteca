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

        public ActionResult Deletar_livro(int id)
        {
            LivrosModel info = _livrosRepositorio.ListarporIdLivro(id);
            return View(info);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                _livrosRepositorio.Deletar(id);
                TempData["MensagemDeleteSucesso"] = "Cadastro do livro deletado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemDeleteErro"] = $"Ops, não foi possível cadastrar o Livro. Tente novamente! Detalhe do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        //Posters - Responsável por armazenar e gravar as informações
        [HttpPost]
        public ActionResult Adicionar_livro(LivrosModel livros)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livrosRepositorio.Adicionar(livros);
                    TempData["MensagemSucesso"] = "Livro cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemPreencha"] = "Preencha os campos faltantes!!";
                    return View(livros);
                }

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar o Livro. Tente novamente! Detalhe do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult Editar_livro(LivrosModel livros)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _livrosRepositorio.Atualizar(livros);
                    TempData["MensagemEditSucesso"] = "Cadastro do livro editado com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemEditPreencha"] = "Preencha os campos faltantes!!";
                    return View(livros);
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemEditErro"] = $"Ops, não foi possível editar o cadastro do livro. Tente novamente! Detalhe do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
