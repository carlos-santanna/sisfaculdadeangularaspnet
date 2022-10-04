using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SisFaculdadeApi.Migrations
{
    public partial class InitialCreateAndInsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursosDisciplinas",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursosDisciplinas", x => new { x.CursoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_CursosDisciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinasAlunos",
                columns: table => new
                {
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinasAlunos", x => new { x.DisciplinaId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_DisciplinasAlunos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinasAlunos_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNascimento", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caio Henrique" },
                    { 21, new DateTime(2001, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaspar Oliveira" },
                    { 22, new DateTime(2000, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Camily Netunes" },
                    { 23, new DateTime(1999, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jessica Heloísa" },
                    { 25, new DateTime(1998, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regina Mendes" },
                    { 26, new DateTime(2000, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro de Sousa" },
                    { 27, new DateTime(2000, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quirino Santos" },
                    { 20, new DateTime(2000, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flora Antonina" },
                    { 28, new DateTime(2000, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alirio Alares" },
                    { 30, new DateTime(2000, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maurício Barbosa" },
                    { 31, new DateTime(1997, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elvira Silva" },
                    { 32, new DateTime(1996, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana Eloísa" },
                    { 33, new DateTime(1995, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miriam Pedrosa" },
                    { 34, new DateTime(1994, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Torres" },
                    { 35, new DateTime(1993, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silvana Abigail" },
                    { 29, new DateTime(2000, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduardo Santi" },
                    { 19, new DateTime(2004, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Itálo Jonas" },
                    { 24, new DateTime(2000, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cinthia Rodrigues" },
                    { 17, new DateTime(2000, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria Antônia" },
                    { 2, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fernando Fernandes" },
                    { 3, new DateTime(2000, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lídia Alteres" },
                    { 18, new DateTime(2000, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcos José" },
                    { 5, new DateTime(2000, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simone Teles" },
                    { 6, new DateTime(1998, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sérgio Ricardo" },
                    { 7, new DateTime(2000, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cleide Silva" },
                    { 8, new DateTime(2000, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "José Arthur" },
                    { 9, new DateTime(2000, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davi Riquelme" },
                    { 4, new DateTime(2000, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afrígia Ramone" },
                    { 11, new DateTime(2002, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaime Leal" },
                    { 12, new DateTime(2000, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro Oliveira" },
                    { 13, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denise Dutra" },
                    { 14, new DateTime(2000, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Igor Godói" },
                    { 15, new DateTime(2003, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Oliveira" },
                    { 16, new DateTime(2000, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billy Regis" },
                    { 10, new DateTime(2000, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Willy Sebára" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 5, "Direito" },
                    { 4, "Serviço Social" },
                    { 3, "Ciências da Comunicação" },
                    { 1, "Ciências da Computação" },
                    { 2, "Marketing e Publicidade" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataNascimento", "Nome", "Salario" },
                values: new object[,]
                {
                    { 7, new DateTime(1990, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana Silva", 1323.0 },
                    { 1, new DateTime(1980, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ângelo Mota", 1323.0 }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataNascimento", "Nome", "Salario" },
                values: new object[,]
                {
                    { 2, new DateTime(1985, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flávia Andrade", 1323.0 },
                    { 3, new DateTime(1978, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hugo Rodrigues", 1323.0 },
                    { 4, new DateTime(1968, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrício Vilella", 1323.0 },
                    { 5, new DateTime(1991, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rafael Oliveira", 1323.0 },
                    { 6, new DateTime(1984, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danilo Martins", 1323.0 },
                    { 8, new DateTime(1963, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rui Fernando", 1323.0 }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "Nome", "ProfessorId" },
                values: new object[,]
                {
                    { 4, "Administração e Serviços de Rede", 1 },
                    { 5, "Estrutura de Dados", 2 },
                    { 12, "Projeto de Conclusão de Curso", 3 },
                    { 1, "Arquitetura de Computadores", 4 },
                    { 2, "Banco de Dados I", 4 },
                    { 3, "Banco de Dados II", 4 },
                    { 6, "Redes de Computadores", 5 },
                    { 9, "Política Social", 6 },
                    { 7, "Sociologia", 7 },
                    { 8, "Direito e Legislação Social", 7 },
                    { 10, "Estado, Sociedade e Movimentos Sociais", 7 },
                    { 11, "Administração e Planejamento em Serviço Social", 7 },
                    { 13, "Direito Administrativo", 8 },
                    { 14, "Direito Penal", 8 },
                    { 15, "Direito Constitucional", 8 },
                    { 16, "Estágio supervisionado", 8 }
                });

            migrationBuilder.InsertData(
                table: "CursosDisciplinas",
                columns: new[] { "CursoId", "DisciplinaId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 6 },
                    { 1, 10 },
                    { 2, 10 },
                    { 3, 10 },
                    { 4, 10 },
                    { 4, 11 },
                    { 5, 11 },
                    { 2, 13 },
                    { 3, 13 },
                    { 4, 13 },
                    { 5, 13 },
                    { 5, 14 },
                    { 5, 15 },
                    { 4, 16 },
                    { 5, 12 },
                    { 4, 12 },
                    { 5, 10 },
                    { 2, 12 },
                    { 1, 5 },
                    { 3, 12 },
                    { 1, 12 }
                });

            migrationBuilder.InsertData(
                table: "DisciplinasAlunos",
                columns: new[] { "AlunoId", "DisciplinaId", "Nota" },
                values: new object[,]
                {
                    { 27, 16, null },
                    { 35, 10, null },
                    { 8, 4, null },
                    { 25, 11, null },
                    { 26, 11, null },
                    { 27, 11, null },
                    { 28, 11, null },
                    { 29, 11, null },
                    { 30, 11, null },
                    { 31, 11, null },
                    { 32, 11, null },
                    { 33, 11, null },
                    { 34, 11, null },
                    { 35, 11, null },
                    { 7, 4, null },
                    { 6, 4, null },
                    { 5, 4, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplinasAlunos",
                columns: new[] { "AlunoId", "DisciplinaId", "Nota" },
                values: new object[,]
                {
                    { 34, 10, null },
                    { 33, 10, null },
                    { 32, 10, null },
                    { 31, 10, null },
                    { 13, 10, null },
                    { 14, 10, null },
                    { 15, 10, null },
                    { 16, 10, null },
                    { 17, 10, null },
                    { 18, 10, null },
                    { 19, 10, null },
                    { 20, 10, null },
                    { 4, 4, null },
                    { 21, 10, null },
                    { 23, 10, null },
                    { 24, 10, null },
                    { 25, 10, null },
                    { 26, 10, null },
                    { 27, 10, null },
                    { 28, 10, null },
                    { 29, 10, null },
                    { 30, 10, null },
                    { 22, 10, null },
                    { 28, 16, null },
                    { 9, 13, null },
                    { 12, 10, null },
                    { 34, 13, null },
                    { 35, 13, null },
                    { 3, 4, null },
                    { 31, 14, null },
                    { 32, 14, null },
                    { 33, 14, null },
                    { 34, 14, null },
                    { 35, 14, null },
                    { 2, 4, null },
                    { 31, 15, null },
                    { 32, 15, null },
                    { 33, 15, null },
                    { 34, 15, null },
                    { 35, 15, null },
                    { 1, 4, null },
                    { 25, 16, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplinasAlunos",
                columns: new[] { "AlunoId", "DisciplinaId", "Nota" },
                values: new object[,]
                {
                    { 26, 16, null },
                    { 33, 13, null },
                    { 32, 13, null },
                    { 31, 13, null },
                    { 30, 13, null },
                    { 12, 13, null },
                    { 13, 13, null },
                    { 14, 13, null },
                    { 15, 13, null },
                    { 16, 13, null },
                    { 17, 13, null },
                    { 18, 13, null },
                    { 19, 13, null },
                    { 10, 13, null },
                    { 20, 13, null },
                    { 22, 13, null },
                    { 23, 13, null },
                    { 24, 13, null },
                    { 25, 13, null },
                    { 26, 13, null },
                    { 27, 13, null },
                    { 28, 13, null },
                    { 29, 13, null },
                    { 21, 13, null },
                    { 11, 13, null },
                    { 10, 10, null },
                    { 9, 10, null },
                    { 23, 12, null },
                    { 24, 12, null },
                    { 25, 12, null },
                    { 26, 12, null },
                    { 27, 12, null },
                    { 28, 12, null },
                    { 29, 12, null },
                    { 30, 12, null },
                    { 22, 12, null },
                    { 31, 12, null },
                    { 33, 12, null },
                    { 34, 12, null },
                    { 35, 12, null },
                    { 8, 5, null },
                    { 1, 1, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplinasAlunos",
                columns: new[] { "AlunoId", "DisciplinaId", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null },
                    { 3, 1, null },
                    { 4, 1, null },
                    { 32, 12, null },
                    { 5, 1, null },
                    { 21, 12, null },
                    { 19, 12, null },
                    { 1, 12, null },
                    { 2, 12, null },
                    { 3, 12, null },
                    { 4, 12, null },
                    { 5, 12, null },
                    { 6, 12, null },
                    { 7, 12, null },
                    { 8, 12, null },
                    { 20, 12, null },
                    { 9, 12, null },
                    { 11, 12, null },
                    { 12, 12, null },
                    { 13, 12, null },
                    { 14, 12, null },
                    { 15, 12, null },
                    { 16, 12, null },
                    { 17, 12, null },
                    { 18, 12, null },
                    { 10, 12, null },
                    { 11, 10, null },
                    { 6, 1, null },
                    { 8, 1, null },
                    { 4, 6, null },
                    { 5, 6, null },
                    { 6, 6, null },
                    { 7, 6, null },
                    { 8, 6, null },
                    { 4, 5, null },
                    { 3, 5, null },
                    { 2, 5, null },
                    { 3, 6, null },
                    { 1, 5, null },
                    { 1, 10, null },
                    { 2, 10, null },
                    { 3, 10, null }
                });

            migrationBuilder.InsertData(
                table: "DisciplinasAlunos",
                columns: new[] { "AlunoId", "DisciplinaId", "Nota" },
                values: new object[,]
                {
                    { 4, 10, null },
                    { 5, 10, null },
                    { 6, 10, null },
                    { 7, 10, null },
                    { 8, 10, null },
                    { 29, 16, null },
                    { 7, 1, null },
                    { 2, 6, null },
                    { 5, 5, null },
                    { 7, 5, null },
                    { 1, 2, null },
                    { 2, 2, null },
                    { 3, 2, null },
                    { 4, 2, null },
                    { 5, 2, null },
                    { 6, 2, null },
                    { 7, 2, null },
                    { 1, 6, null },
                    { 8, 2, null },
                    { 1, 3, null },
                    { 2, 3, null },
                    { 3, 3, null },
                    { 4, 3, null },
                    { 5, 3, null },
                    { 6, 3, null },
                    { 7, 3, null },
                    { 8, 3, null },
                    { 6, 5, null },
                    { 30, 16, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursosDisciplinas_DisciplinaId",
                table: "CursosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinasAlunos_AlunoId",
                table: "DisciplinasAlunos",
                column: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursosDisciplinas");

            migrationBuilder.DropTable(
                name: "DisciplinasAlunos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
