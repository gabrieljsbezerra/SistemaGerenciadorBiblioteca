using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int? Id_aluno { get; set; }

        [ForeignKey("Id_aluno")]
        public AlunosModel Aluno { get; set; }

        [Required(ErrorMessage = "Selecione um Livro!")]
        public int? Id_livro { get; set; }

        [ForeignKey("Id_livro")]
        public LivrosModel Livro { get; set; }
    }
}

