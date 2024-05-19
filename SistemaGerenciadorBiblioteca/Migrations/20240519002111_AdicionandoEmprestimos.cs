using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGerenciadorBiblioteca.Migrations
{
    public partial class AdicionandoEmprestimos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmprestimosModel",
                columns: table => new
                {
                    Id_emprestimo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Emprestimo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Devolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_aluno = table.Column<int>(type: "int", nullable: false),
                    Id_livro = table.Column<int>(type: "int", nullable: false),
                    LivroId_livro = table.Column<int>(type: "int", nullable: false),
                    AlunoId_aluno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmprestimosModel", x => x.Id_emprestimo);
                    table.ForeignKey(
                        name: "FK_EmprestimosModel_Alunos_AlunoId_aluno",
                        column: x => x.AlunoId_aluno,
                        principalTable: "Alunos",
                        principalColumn: "Id_aluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmprestimosModel_Livros_LivroId_livro",
                        column: x => x.LivroId_livro,
                        principalTable: "Livros",
                        principalColumn: "Id_livro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmprestimosModel_AlunoId_aluno",
                table: "EmprestimosModel",
                column: "AlunoId_aluno");

            migrationBuilder.CreateIndex(
                name: "IX_EmprestimosModel_LivroId_livro",
                table: "EmprestimosModel",
                column: "LivroId_livro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmprestimosModel");
        }
    }
}
