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

        [Required(ErrorMessage = "Selecione um Aluno!")]
        public int Id_aluno { get; set; }

        [Required(ErrorMessage = "Selecione um Livro!")]
        public int Id_livro { get; set; }
        public LivrosModel? Livro { get; set; }
        public AlunosModel? Aluno { get; set; }

    }
}
