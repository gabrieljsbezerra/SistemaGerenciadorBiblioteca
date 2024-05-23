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
            return RedirectToAction("Index");
        }
    }
}

