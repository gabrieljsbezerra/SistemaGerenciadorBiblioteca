using System.ComponentModel.DataAnnotations;

namespace SistemaGerenciadorBiblioteca.Models
{
    public class AlunosModel
    {
        [Key]
        public int Id_aluno { get; set; }
        public int Rm { get; set; }
        public string Nome_Aluno { get; set; }
        public string Turma { get; set; }
        public string Nome_Responsavel { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }

    }
}