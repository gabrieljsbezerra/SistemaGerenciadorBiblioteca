﻿using SistemaGerenciadorBiblioteca.Models;

namespace SistemaGerenciadorBiblioteca.Repositorio
{
    public interface ILivrosRepositorio
    {
        LivrosModel ListarporIdLivro(int id);
        List<LivrosModel> BuscarCadastroLivro();
        LivrosModel Adicionar(LivrosModel livros);
    }
}
