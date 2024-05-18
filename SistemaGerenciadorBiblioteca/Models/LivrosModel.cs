using System.ComponentModel.DataAnnotations;

namespace SistemaGerenciadorBiblioteca.Models
{
    public class LivrosModel
    {
        [Key] 
        public int Id_livro { get; set; }
        
        [Required(ErrorMessage = "Digite o Título do Livro")]
        public string Titulo { get; set; }
       
        [Required(ErrorMessage = "Digite o Autor do Livro")]
        public string Autor { get; set; }
        
        [Required(ErrorMessage = "Digite o Genêro do Livro")]
        public string Genero { get; set; }
        
        [Required(ErrorMessage = "Digite a Editora do Livro")]
        public string Editora { get; set; }
        
        [Required(ErrorMessage = "Digite o Ano de Publicação do Livro")]
        public int Ano { get; set; }

    }
}
