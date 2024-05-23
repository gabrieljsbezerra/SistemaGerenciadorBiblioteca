using SistemaGerenciadorBiblioteca.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaGerenciadorBiblioteca.ViewModel
{
    public class EmprestimosViewModel : EmprestimosModel
    {
        public List<LivrosModel> ListaLivros { get; set; }
        public List<AlunosModel> ListaAlunos { get; set; }

    }
}
