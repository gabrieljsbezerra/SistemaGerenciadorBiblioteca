using System.ComponentModel.DataAnnotations;

namespace SistemaGerenciadorBiblioteca.Models
{
    public class LivrosModel
    {
        [Key] 
        public int Id_livro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string Editora { get; set; }
        public int Ano { get; set; }

    }
}
