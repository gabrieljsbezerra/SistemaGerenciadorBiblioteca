﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SistemaGerenciadorBiblioteca.Models
{
    public class AlunosModel
    {
        [Key]
        public int Id_aluno { get; set; }

        [Required(ErrorMessage = "Digite o Registro de Matrícula do Aluno!")]
        public int Rm { get; set; }

        [Required(ErrorMessage = "Digite o Nome do Aluno!")]
        public string Nome_Aluno { get; set; }

        [Required(ErrorMessage = "Digite a Turma a qual o Aluno pertence!")]
        public string Turma { get; set; }

        [Required(ErrorMessage = "Digite o Nome do Responsável!")]
        public string Nome_Responsavel { get; set; }

        [Required(ErrorMessage = "Digite o número de Celular para contato!")]
        [Phone(ErrorMessage = "Celular informado é inválido!")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Digite o E-mail para contato!")]
        [EmailAddress(ErrorMessage = "E-mail informado não é válido!")]
        public string Email { get; set; }

    }
}