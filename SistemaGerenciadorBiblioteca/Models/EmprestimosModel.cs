using System.ComponentModel.DataAnnotations;

namespace SistemaGerenciadorBiblioteca.Models
{
    public class EmprestimosModel
    {
        [Key]
        public int Id_emprestimo { get; set; }

        [Required(ErrorMessage = "Digite a data de empréstimo!")]
        public DateTime Data_Emprestimo { get; set; }

        [Required(ErrorMessage = "Digite a data de devolução!")]
        public DateTime Data_Devolucao { get; set; }

        public int Id_aluno { get; set; }

        public int Id_livro { get; set; }
        public LivrosModel Livro { get; set; }
        public AlunosModel Aluno { get; set; }

    }
}
