using Microsoft.EntityFrameworkCore.Migrations;

namespace SisFaculdadeApi.Migrations
{
    public partial class changetabelacursoaluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DisciplinasAlunos",
                table: "DisciplinasAlunos");

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 11, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 12, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 13, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 14, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 15, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 16, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 17, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 18, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 19, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 20, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 21, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 22, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 23, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 24, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 25, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 26, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 27, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 28, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 29, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 30, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 31, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 32, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 33, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 34, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 35, 10 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 25, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 26, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 27, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 28, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 29, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 30, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 31, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 32, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 33, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 34, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 35, 11 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 7, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 8, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 9, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 10, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 11, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 12, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 13, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 14, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 15, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 16, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 17, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 18, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 19, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 20, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 21, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 22, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 23, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 24, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 25, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 26, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 27, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 28, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 29, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 30, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 31, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 32, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 33, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 34, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 35, 12 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 9, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 11, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 12, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 13, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 14, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 15, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 16, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 17, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 18, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 19, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 20, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 21, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 22, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 23, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 24, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 25, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 26, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 27, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 28, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 29, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 30, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 31, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 32, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 33, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 34, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 35, 13 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 31, 14 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 32, 14 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 33, 14 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 34, 14 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 35, 14 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 31, 15 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 32, 15 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 33, 15 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 34, 15 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 35, 15 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 25, 16 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 26, 16 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 27, 16 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 28, 16 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 29, 16 });

            migrationBuilder.DeleteData(
                table: "DisciplinasAlunos",
                keyColumns: new[] { "AlunoId", "DisciplinaId" },
                keyValues: new object[] { 30, 16 });

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "DisciplinasAlunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisciplinasAlunos",
                table: "DisciplinasAlunos",
                columns: new[] { "DisciplinaId", "AlunoId", "CursoId" });

            migrationBuilder.InsertData(
                table: "DisciplinasAlunos",
                columns: new[] { "AlunoId", "CursoId", "DisciplinaId", "Nota" },
                values: new object[,]
                {
                    { 1, 1, 1, null },
                    { 23, 3, 13, null },
                    { 24, 3, 13, null },
                    { 25, 4, 10, null },
                    { 26, 4, 10, null },
                    { 27, 4, 10, null },
                    { 28, 4, 10, null },
                    { 29, 4, 10, null },
                    { 30, 4, 10, null },
                    { 25, 4, 11, null },
                    { 26, 4, 11, null },
                    { 27, 4, 11, null },
                    { 28, 4, 11, null },
                    { 29, 4, 11, null },
                    { 30, 4, 11, null },
                    { 25, 4, 12, null },
                    { 26, 4, 12, null },
                    { 27, 4, 12, null },
                    { 22, 3, 13, null },
                    { 21, 3, 13, null },
                    { 20, 3, 13, null },
                    { 19, 3, 13, null },
                    { 13, 2, 13, null },
                    { 14, 2, 13, null },
                    { 15, 2, 13, null },
                    { 16, 2, 13, null },
                    { 17, 2, 13, null },
                    { 18, 2, 13, null },
                    { 19, 3, 10, null },
                    { 20, 3, 10, null },
                    { 28, 4, 12, null },
                    { 21, 3, 10, null },
                    { 23, 3, 10, null },
                    { 24, 3, 10, null },
                    { 19, 3, 12, null },
                    { 20, 3, 12, null },
                    { 21, 3, 12, null },
                    { 22, 3, 12, null },
                    { 23, 3, 12, null },
                    { 24, 3, 12, null },
                    { 22, 3, 10, null },
                    { 12, 2, 13, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplinasAlunos",
                columns: new[] { "AlunoId", "CursoId", "DisciplinaId", "Nota" },
                values: new object[,]
                {
                    { 29, 4, 12, null },
                    { 25, 4, 13, null },
                    { 32, 5, 12, null },
                    { 33, 5, 12, null },
                    { 34, 5, 12, null },
                    { 35, 5, 12, null },
                    { 31, 5, 13, null },
                    { 32, 5, 13, null },
                    { 33, 5, 13, null },
                    { 34, 5, 13, null },
                    { 35, 5, 13, null },
                    { 31, 5, 14, null },
                    { 32, 5, 14, null },
                    { 33, 5, 14, null },
                    { 34, 5, 14, null },
                    { 35, 5, 14, null },
                    { 31, 5, 15, null },
                    { 32, 5, 15, null },
                    { 33, 5, 15, null },
                    { 31, 5, 12, null },
                    { 35, 5, 11, null },
                    { 34, 5, 11, null },
                    { 33, 5, 11, null },
                    { 26, 4, 13, null },
                    { 27, 4, 13, null },
                    { 28, 4, 13, null },
                    { 29, 4, 13, null },
                    { 30, 4, 13, null },
                    { 25, 4, 16, null },
                    { 26, 4, 16, null },
                    { 27, 4, 16, null },
                    { 30, 4, 12, null },
                    { 28, 4, 16, null },
                    { 30, 4, 16, null },
                    { 31, 5, 10, null },
                    { 32, 5, 10, null },
                    { 33, 5, 10, null },
                    { 34, 5, 10, null },
                    { 35, 5, 10, null },
                    { 31, 5, 11, null },
                    { 32, 5, 11, null },
                    { 29, 4, 16, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplinasAlunos",
                columns: new[] { "AlunoId", "CursoId", "DisciplinaId", "Nota" },
                values: new object[,]
                {
                    { 11, 2, 13, null },
                    { 10, 2, 13, null },
                    { 9, 2, 13, null },
                    { 8, 1, 3, null },
                    { 1, 1, 4, null },
                    { 2, 1, 4, null },
                    { 3, 1, 4, null },
                    { 4, 1, 4, null },
                    { 5, 1, 4, null },
                    { 6, 1, 4, null },
                    { 7, 1, 4, null },
                    { 8, 1, 4, null },
                    { 1, 1, 5, null },
                    { 2, 1, 5, null },
                    { 3, 1, 5, null },
                    { 4, 1, 5, null },
                    { 5, 1, 5, null },
                    { 6, 1, 5, null },
                    { 7, 1, 5, null },
                    { 8, 1, 5, null },
                    { 7, 1, 3, null },
                    { 6, 1, 3, null },
                    { 5, 1, 3, null },
                    { 4, 1, 3, null },
                    { 2, 1, 1, null },
                    { 3, 1, 1, null },
                    { 4, 1, 1, null },
                    { 5, 1, 1, null },
                    { 6, 1, 1, null },
                    { 7, 1, 1, null },
                    { 8, 1, 1, null },
                    { 1, 1, 2, null },
                    { 1, 1, 6, null },
                    { 2, 1, 2, null },
                    { 4, 1, 2, null },
                    { 5, 1, 2, null },
                    { 6, 1, 2, null },
                    { 7, 1, 2, null },
                    { 8, 1, 2, null },
                    { 1, 1, 3, null },
                    { 2, 1, 3, null },
                    { 3, 1, 3, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplinasAlunos",
                columns: new[] { "AlunoId", "CursoId", "DisciplinaId", "Nota" },
                values: new object[,]
                {
                    { 3, 1, 2, null },
                    { 2, 1, 6, null },
                    { 3, 1, 6, null },
                    { 4, 1, 6, null },
                    { 11, 2, 10, null },
                    { 12, 2, 10, null },
                    { 13, 2, 10, null },
                    { 14, 2, 10, null },
                    { 15, 2, 10, null },
                    { 16, 2, 10, null },
                    { 17, 2, 10, null },
                    { 18, 2, 10, null },
                    { 10, 2, 10, null },
                    { 9, 2, 12, null },
                    { 11, 2, 12, null },
                    { 12, 2, 12, null },
                    { 13, 2, 12, null },
                    { 14, 2, 12, null },
                    { 15, 2, 12, null },
                    { 16, 2, 12, null },
                    { 17, 2, 12, null },
                    { 18, 2, 12, null },
                    { 10, 2, 12, null },
                    { 34, 5, 15, null },
                    { 9, 2, 10, null },
                    { 7, 1, 12, null },
                    { 5, 1, 6, null },
                    { 6, 1, 6, null },
                    { 7, 1, 6, null },
                    { 8, 1, 6, null },
                    { 1, 1, 10, null },
                    { 2, 1, 10, null },
                    { 3, 1, 10, null },
                    { 4, 1, 10, null },
                    { 8, 1, 12, null },
                    { 5, 1, 10, null },
                    { 7, 1, 10, null },
                    { 8, 1, 10, null },
                    { 1, 1, 12, null },
                    { 2, 1, 12, null },
                    { 3, 1, 12, null },
                    { 4, 1, 12, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplinasAlunos",
                columns: new[] { "AlunoId", "CursoId", "DisciplinaId", "Nota" },
                values: new object[,]
                {
                    { 5, 1, 12, null },
                    { 6, 1, 12, null },
                    { 6, 1, 10, null },
                    { 35, 5, 15, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinasAlunos_CursoId",
                table: "DisciplinasAlunos",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinasAlunos_Cursos_CursoId",
                table: "DisciplinasAlunos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplinasAlunos_Cursos_CursoId",
                table: "DisciplinasAlunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DisciplinasAlunos",
                table: "DisciplinasAlunos");

            migrationBuilder.DropIndex(
                name: "IX_DisciplinasAlunos_CursoId",
                table: "DisciplinasAlunos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "DisciplinasAlunos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisciplinasAlunos",
                table: "DisciplinasAlunos",
                columns: new[] { "DisciplinaId", "AlunoId" });
        }
    }
}
