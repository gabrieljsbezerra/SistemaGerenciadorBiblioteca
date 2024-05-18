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
            try
            {
                _alunosRepositorio.Deletar(id);
                TempData["MensagemDeleteSucesso"] = "Cadastro do aluno deletado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemDeleteErro"] = $"Ops, não foi possível deletar o cadastro do aluno. Tente novamente! Detalhe do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
        //Posters - Responsável por armazenar e gravar as informações
        [HttpPost]
        public ActionResult Adicionar_aluno(AlunosModel alunos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alunosRepositorio.Adicionar(alunos);
                    TempData["MensagemSucesso"] = "Aluno cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemPreencha"] = "Preencha os campos faltantes!!";
                    return View(alunos);
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar o Aluno. Tente novamente! Detalhe do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult Editar_aluno(AlunosModel alunos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _alunosRepositorio.Atualizar(alunos);
                    TempData["MensagemEditSucesso"] = "Cadastro do aluno editado com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemEditPreencha"] = "Preencha os campos faltantes!!";
                    return View(alunos);
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemEditErro"] = $"Ops, não foi possível editar o cadastro do aluno. Tente novamente! Detalhe do Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
