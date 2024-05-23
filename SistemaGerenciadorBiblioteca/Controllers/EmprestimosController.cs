using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorBiblioteca.Data;
using SistemaGerenciadorBiblioteca.Models;
using SistemaGerenciadorBiblioteca.Repositorio;
using SistemaGerenciadorBiblioteca.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGerenciadorBiblioteca.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly BancoContext _context;

        public EmprestimosController(BancoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var emprestimos = _context.Emprestimos
                                      .Include(e => e.Livro)
                                      .Include(e => e.Aluno)
                                      .ToList();
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Add()
        {
            EmprestimosViewModel model = new EmprestimosViewModel();
            model.ListaLivros = _context.Livros.ToList();
            model.ListaAlunos = _context.Alunos.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(EmprestimosViewModel AddEmprestimo)
        {

            var emprestimo = new EmprestimosModel
            {
                Data_Emprestimo = AddEmprestimo.Data_Emprestimo,
                Data_Devolucao = AddEmprestimo.Data_Devolucao,
                Id_aluno = AddEmprestimo.Id_aluno,
                Id_livro = AddEmprestimo.Id_livro
            };

            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
            TempData["MensagemSucesso"] = "Empréstimo cadastrado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emprestimo = _context.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            var model = new EmprestimosViewModel
            {
                Id_emprestimo = emprestimo.Id_emprestimo,
                Data_Emprestimo = emprestimo.Data_Emprestimo,
                Data_Devolucao = emprestimo.Data_Devolucao,
                Id_aluno = emprestimo.Id_aluno,
                Id_livro = emprestimo.Id_livro,
                ListaAlunos = _context.Alunos.ToList(),
                ListaLivros = _context.Livros.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmprestimosViewModel model)
        {
            var emprestimo = _context.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            emprestimo.Data_Emprestimo = model.Data_Emprestimo;
            emprestimo.Data_Devolucao = model.Data_Devolucao;
            emprestimo.Id_aluno = model.Id_aluno;
            emprestimo.Id_livro = model.Id_livro;

            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();
            TempData["MensagemEditSucesso"] = "Empréstimo editado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ConfirmarDelete(int id)
        {
            var emprestimo = _context.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var emprestimo = _context.Emprestimos.Find(id);

            _context.Emprestimos.Remove(emprestimo);
            _context.SaveChanges();
            TempData["MensagemDeleteSucesso"] = "Empréstimo deletado com sucesso!";
            return RedirectToAction("Index");
        }

    }
}

