using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SisFaculdadeApi.Models;

namespace SisFaculdadeApi.Data
{
    public class AppDbContext: DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        // muitos para muitos
        public DbSet<DisciplinaAluno> DisciplinasAlunos { get; set; }
        public DbSet<CursoDisciplina> CursosDisciplinas { get; set; }

        public DbSet<AlunoCurso> AlunosCursos { get; set; }

        protected override void  OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DisciplinaAluno>(entity =>{
                entity.HasKey(e=> new {
                    e.DisciplinaId,
                    e.AlunoId,
                    e.CursoId
                });
            });

            builder.Entity<CursoDisciplina>(entity =>{
                entity.HasKey(e=> new {
                    e.CursoId,
                    e.DisciplinaId
                });
            });

            builder.Entity<AlunoCurso>(entity => {
                entity.HasKey(e => new {
                    e.AlunoId,
                    e.CursoId
                });
            });


            // adicionando dados iniciais no banco de dados
            builder.Entity<Professor>()
            .HasData(new List<Professor>{
                new Professor(1, "Ângelo Mota", Convert.ToDateTime("1980-05-08"), 1323.00 ),                
                new Professor(2, "Flávia Andrade", Convert.ToDateTime("1985-08-01"), 1323.00 ),
                new Professor(3, "Hugo Rodrigues", Convert.ToDateTime("1978-01-18"), 1323.00 ),
                new Professor(4, "Patrício Vilella", Convert.ToDateTime("1968-09-06"), 1323.00 ),
                new Professor(5, "Rafael Oliveira",Convert.ToDateTime( "1991-05-01"), 1323.00 ),
                new Professor(6, "Danilo Martins", Convert.ToDateTime("1984-06-01"), 1323.00 ),                
                new Professor(7, "Ana Silva", Convert.ToDateTime("1990-10-16"), 1323.00 ),
                new Professor(8, "Rui Fernando", Convert.ToDateTime("1963-07-09"), 1323.00 )
            });

            builder.Entity<Curso>()
            .HasData(new List<Curso>{
                new Curso(1, "Ciências da Computação" ),
                new Curso(2, "Marketing e Publicidade"),
                new Curso(3, "Ciências da Comunicação"),
                new Curso(4, "Serviço Social"),
                new Curso(5, "Direito")
            });

            builder.Entity<Disciplina>()
            .HasData(new List<Disciplina>{
                new Disciplina(1, "Arquitetura de Computadores", 4),
                new Disciplina(2, "Banco de Dados I", 4),
                new Disciplina(3, "Banco de Dados II", 4),
                new Disciplina(4, "Administração e Serviços de Rede", 1),
                new Disciplina(5, "Estrutura de Dados", 2),
                new Disciplina(6, "Redes de Computadores", 5),
                new Disciplina(7, "Sociologia", 7),
                new Disciplina(8, "Direito e Legislação Social", 7),
                new Disciplina(9, "Política Social", 6),
                new Disciplina(10, "Estado, Sociedade e Movimentos Sociais", 7),
                new Disciplina(11, "Administração e Planejamento em Serviço Social", 7),
                new Disciplina(12, "Projeto de Conclusão de Curso", 3),
                new Disciplina(13, "Direito Administrativo", 8),
                new Disciplina(14, "Direito Penal", 8),
                new Disciplina(15, "Direito Constitucional", 8),
                new Disciplina(16, "Estágio supervisionado", 8)
            });


            builder.Entity<CursoDisciplina>()
            .HasData(new List<CursoDisciplina>{
                new CursoDisciplina(1, 1),
                new CursoDisciplina(1, 2),
                new CursoDisciplina(1, 3),
                new CursoDisciplina(1, 4),
                new CursoDisciplina(1, 5),
                new CursoDisciplina(1, 6),
                new CursoDisciplina(1, 10),
                new CursoDisciplina(1, 12),
                new CursoDisciplina(2, 10),
                new CursoDisciplina(2, 12),
                new CursoDisciplina(2, 13),
                new CursoDisciplina(3, 10),
                new CursoDisciplina(3, 12),
                new CursoDisciplina(3, 13),
                new CursoDisciplina(4, 10),
                new CursoDisciplina(4, 12),
                new CursoDisciplina(4, 11),
                new CursoDisciplina(4, 13),
                new CursoDisciplina(4, 16),
                new CursoDisciplina(5, 10),
                new CursoDisciplina(5, 12),
                new CursoDisciplina(5, 11),
                new CursoDisciplina(5, 13),
                new CursoDisciplina(5, 14),
                new CursoDisciplina(5, 15)
            });


            builder.Entity<Aluno>()
            .HasData(new List<Aluno>{
                new Aluno(1, Convert.ToDateTime("2000-12-01"), "Caio Henrique" ),
                new Aluno(2, Convert.ToDateTime("1995-01-01"), "Fernando Fernandes" ),
                new Aluno(3,  Convert.ToDateTime("2000-02-03"), "Lídia Alteres" ),
                new Aluno(4,  Convert.ToDateTime("2000-03-04"), "Afrígia Ramone" ),
                new Aluno(5,  Convert.ToDateTime("2000-04-05"), "Simone Teles" ),
                new Aluno(6,  Convert.ToDateTime("1998-05-06"), "Sérgio Ricardo" ),
                new Aluno(7,  Convert.ToDateTime("2000-06-07"), "Cleide Silva" ),
                new Aluno(8,  Convert.ToDateTime("2000-07-08"), "José Arthur" ),
                new Aluno(9,  Convert.ToDateTime("2000-08-09"), "Davi Riquelme" ),
                new Aluno(10, Convert.ToDateTime( "2000-09-10"), "Willy Sebára" ),
                new Aluno(11, Convert.ToDateTime( "2002-10-11"), "Jaime Leal" ),
                new Aluno(12, Convert.ToDateTime( "2000-11-12"), "Pedro Oliveira" ),
                new Aluno(13, Convert.ToDateTime( "2000-12-13"), "Denise Dutra" ),
                new Aluno(14, Convert.ToDateTime( "2000-01-14"), "Igor Godói" ),
                new Aluno(15, Convert.ToDateTime( "2003-02-15"), "Denis Oliveira" ),
                new Aluno(16, Convert.ToDateTime( "2000-03-16"), "Billy Regis" ),
                new Aluno(17, Convert.ToDateTime( "2000-04-17"), "Maria Antônia" ),
                new Aluno(18, Convert.ToDateTime( "2000-05-18"), "Marcos José" ),
                new Aluno(19, Convert.ToDateTime( "2004-06-19"), "Itálo Jonas" ),
                new Aluno(20, Convert.ToDateTime( "2000-07-20"), "Flora Antonina" ),
                new Aluno(21, Convert.ToDateTime( "2001-08-21"), "Gaspar Oliveira" ),
                new Aluno(22, Convert.ToDateTime( "2000-09-22"), "Camily Netunes" ),
                new Aluno(23, Convert.ToDateTime( "1999-10-23"), "Jessica Heloísa" ),
                new Aluno(24, Convert.ToDateTime( "2000-11-24"), "Cinthia Rodrigues" ),
                new Aluno(25, Convert.ToDateTime( "1998-12-25"), "Regina Mendes" ),
                new Aluno(26, Convert.ToDateTime( "2000-01-26"), "Pedro de Sousa" ),
                new Aluno(27, Convert.ToDateTime( "2000-02-27"), "Quirino Santos" ),
                new Aluno(28, Convert.ToDateTime( "2000-03-28"), "Alirio Alares" ),
                new Aluno(29, Convert.ToDateTime( "2000-04-29"), "Eduardo Santi" ),
                new Aluno(30, Convert.ToDateTime( "2000-05-30"), "Maurício Barbosa" ),
                new Aluno(31, Convert.ToDateTime( "1997-06-01"), "Elvira Silva" ),
                new Aluno(32, Convert.ToDateTime( "1996-07-02"), "Ana Eloísa" ),
                new Aluno(33, Convert.ToDateTime( "1995-08-03"), "Miriam Pedrosa" ),
                new Aluno(34, Convert.ToDateTime( "1994-09-04"), "Carlos Torres" ),
                new Aluno(35, Convert.ToDateTime( "1993-10-05"), "Silvana Abigail" )
            });


            builder.Entity<DisciplinaAluno>()
            .HasData(new List<DisciplinaAluno>{
                new DisciplinaAluno(1, 1, 1),
                new DisciplinaAluno(2, 1, 1),
                new DisciplinaAluno(3, 1, 1),
                new DisciplinaAluno(4, 1, 1),
                new DisciplinaAluno(5, 1, 1),
                new DisciplinaAluno(6, 1, 1),
                new DisciplinaAluno(7, 1, 1),
                new DisciplinaAluno(8, 1, 1),
                new DisciplinaAluno(1, 2, 1),
                new DisciplinaAluno(2, 2, 1),
                new DisciplinaAluno(3, 2, 1),
                new DisciplinaAluno(4, 2, 1),
                new DisciplinaAluno(5, 2, 1),
                new DisciplinaAluno(6, 2, 1),
                new DisciplinaAluno(7, 2, 1),
                new DisciplinaAluno(8, 2, 1),
                new DisciplinaAluno(1, 3, 1),
                new DisciplinaAluno(2, 3, 1),
                new DisciplinaAluno(3, 3, 1),
                new DisciplinaAluno(4, 3, 1),
                new DisciplinaAluno(5, 3, 1),
                new DisciplinaAluno(6, 3, 1),
                new DisciplinaAluno(7, 3, 1),
                new DisciplinaAluno(8, 3, 1),
                new DisciplinaAluno(1, 4, 1),
                new DisciplinaAluno(2, 4, 1),
                new DisciplinaAluno(3, 4, 1),
                new DisciplinaAluno(4, 4, 1),
                new DisciplinaAluno(5, 4, 1),
                new DisciplinaAluno(6, 4, 1),
                new DisciplinaAluno(7, 4, 1),
                new DisciplinaAluno(8, 4, 1),
                new DisciplinaAluno(1, 5, 1),
                new DisciplinaAluno(2, 5, 1),
                new DisciplinaAluno(3, 5, 1),
                new DisciplinaAluno(4, 5, 1),
                new DisciplinaAluno(5, 5, 1),
                new DisciplinaAluno(6, 5, 1),
                new DisciplinaAluno(7, 5, 1),
                new DisciplinaAluno(8, 5, 1),
                new DisciplinaAluno(1, 6, 1),
                new DisciplinaAluno(2, 6, 1),
                new DisciplinaAluno(3, 6, 1),
                new DisciplinaAluno(4, 6, 1),
                new DisciplinaAluno(5, 6, 1),
                new DisciplinaAluno(6, 6, 1),
                new DisciplinaAluno(7, 6, 1),
                new DisciplinaAluno(8, 6, 1),
                new DisciplinaAluno(1, 10, 1),
                new DisciplinaAluno(2, 10, 1),
                new DisciplinaAluno(3, 10, 1),
                new DisciplinaAluno(4, 10, 1),
                new DisciplinaAluno(5, 10, 1),
                new DisciplinaAluno(6, 10, 1),
                new DisciplinaAluno(7, 10, 1),
                new DisciplinaAluno(8, 10, 1),
                new DisciplinaAluno(1, 12, 1),
                new DisciplinaAluno(2, 12, 1),
                new DisciplinaAluno(3, 12, 1),
                new DisciplinaAluno(4, 12, 1),
                new DisciplinaAluno(5, 12, 1),
                new DisciplinaAluno(6, 12, 1),
                new DisciplinaAluno(7, 12, 1),
                new DisciplinaAluno(8, 12, 1),
                new DisciplinaAluno(9, 10, 2),
                new DisciplinaAluno(10, 10, 2),
                new DisciplinaAluno(11, 10, 2),
                new DisciplinaAluno(12, 10, 2),
                new DisciplinaAluno(13, 10, 2),
                new DisciplinaAluno(14, 10, 2),
                new DisciplinaAluno(15, 10, 2),
                new DisciplinaAluno(16, 10, 2),
                new DisciplinaAluno(17, 10, 2),
                new DisciplinaAluno(18, 10, 2),
                new DisciplinaAluno(9, 12, 2),
                new DisciplinaAluno(10, 12, 2),
                new DisciplinaAluno(11, 12, 2),
                new DisciplinaAluno(12, 12, 2),
                new DisciplinaAluno(13, 12, 2),
                new DisciplinaAluno(14, 12, 2),
                new DisciplinaAluno(15, 12, 2),
                new DisciplinaAluno(16, 12, 2),
                new DisciplinaAluno(17, 12, 2),
                new DisciplinaAluno(18, 12, 2),
                new DisciplinaAluno(9, 13, 2),
                new DisciplinaAluno(10, 13, 2),
                new DisciplinaAluno(11, 13, 2),
                new DisciplinaAluno(12, 13, 2),
                new DisciplinaAluno(13, 13, 2),
                new DisciplinaAluno(14, 13, 2),
                new DisciplinaAluno(15, 13, 2),
                new DisciplinaAluno(16, 13, 2),
                new DisciplinaAluno(17, 13, 2),
                new DisciplinaAluno(18, 13, 2),
                new DisciplinaAluno(19, 10, 3),
                new DisciplinaAluno(20, 10, 3),
                new DisciplinaAluno(21, 10, 3),
                new DisciplinaAluno(22, 10, 3),
                new DisciplinaAluno(23, 10, 3),
                new DisciplinaAluno(24, 10, 3),
                new DisciplinaAluno(19, 12, 3),
                new DisciplinaAluno(20, 12, 3),
                new DisciplinaAluno(21, 12, 3),
                new DisciplinaAluno(22, 12, 3),
                new DisciplinaAluno(23, 12, 3),
                new DisciplinaAluno(24, 12, 3),
                new DisciplinaAluno(19, 13, 3),
                new DisciplinaAluno(20, 13, 3),
                new DisciplinaAluno(21, 13, 3),
                new DisciplinaAluno(22, 13, 3),
                new DisciplinaAluno(23, 13, 3),
                new DisciplinaAluno(24, 13, 3),
                new DisciplinaAluno(25, 10, 4),
                new DisciplinaAluno(26, 10, 4),
                new DisciplinaAluno(27, 10, 4),
                new DisciplinaAluno(28, 10, 4),
                new DisciplinaAluno(29, 10, 4),
                new DisciplinaAluno(30, 10, 4),
                new DisciplinaAluno(25, 11, 4),
                new DisciplinaAluno(26, 11, 4),
                new DisciplinaAluno(27, 11, 4),
                new DisciplinaAluno(28, 11, 4),
                new DisciplinaAluno(29, 11, 4),
                new DisciplinaAluno(30, 11, 4),
                new DisciplinaAluno(25, 12, 4),
                new DisciplinaAluno(26, 12, 4),
                new DisciplinaAluno(27, 12, 4),
                new DisciplinaAluno(28, 12, 4),
                new DisciplinaAluno(29, 12, 4),
                new DisciplinaAluno(30, 12, 4),
                new DisciplinaAluno(25, 13, 4),
                new DisciplinaAluno(26, 13, 4),
                new DisciplinaAluno(27, 13, 4),
                new DisciplinaAluno(28, 13, 4),
                new DisciplinaAluno(29, 13, 4),
                new DisciplinaAluno(30, 13, 4),
                new DisciplinaAluno(25, 16, 4),
                new DisciplinaAluno(26, 16, 4),
                new DisciplinaAluno(27, 16, 4),
                new DisciplinaAluno(28, 16, 4),
                new DisciplinaAluno(29, 16, 4),
                new DisciplinaAluno(30, 16, 4),
                new DisciplinaAluno(31, 10, 5),
                new DisciplinaAluno(32, 10, 5),
                new DisciplinaAluno(33, 10, 5),
                new DisciplinaAluno(34, 10, 5),
                new DisciplinaAluno(35, 10, 5),
                new DisciplinaAluno(31, 11, 5),
                new DisciplinaAluno(32, 11, 5),
                new DisciplinaAluno(33, 11, 5),
                new DisciplinaAluno(34, 11, 5),
                new DisciplinaAluno(35, 11, 5),
                new DisciplinaAluno(31, 12, 5),
                new DisciplinaAluno(32, 12, 5),
                new DisciplinaAluno(33, 12, 5),
                new DisciplinaAluno(34, 12, 5),
                new DisciplinaAluno(35, 12, 5),
                new DisciplinaAluno(31, 13, 5),
                new DisciplinaAluno(32, 13, 5),
                new DisciplinaAluno(33, 13, 5),
                new DisciplinaAluno(34, 13, 5),
                new DisciplinaAluno(35, 13, 5),
                new DisciplinaAluno(31, 14, 5),
                new DisciplinaAluno(32, 14, 5),
                new DisciplinaAluno(33, 14, 5),
                new DisciplinaAluno(34, 14, 5),
                new DisciplinaAluno(35, 14, 5),
                new DisciplinaAluno(31, 15, 5),
                new DisciplinaAluno(32, 15, 5),
                new DisciplinaAluno(33, 15, 5),
                new DisciplinaAluno(34, 15, 5),
                new DisciplinaAluno(35, 15, 5)
            });


            builder.Entity<AlunoCurso>()
            .HasData(new List<AlunoCurso>{
                new AlunoCurso(1, 1),
                new AlunoCurso(2, 1),
                new AlunoCurso(3, 1),
                new AlunoCurso(4, 1),
                new AlunoCurso(5, 1),
                new AlunoCurso(6, 1),
                new AlunoCurso(7, 1),
                new AlunoCurso(8, 1),
                new AlunoCurso(9, 2),
                new AlunoCurso(10, 2),
                new AlunoCurso(11, 2),
                new AlunoCurso(12, 2),
                new AlunoCurso(13, 2),
                new AlunoCurso(14, 2),
                new AlunoCurso(15, 2),
                new AlunoCurso(16, 2),
                new AlunoCurso(17, 2),
                new AlunoCurso(18, 2),
                new AlunoCurso(19, 3),
                new AlunoCurso(20, 3),
                new AlunoCurso(21, 3),
                new AlunoCurso(22, 3),
                new AlunoCurso(23, 3),
                new AlunoCurso(24, 3),
                new AlunoCurso(25, 4),
                new AlunoCurso(26, 4),
                new AlunoCurso(27, 4),
                new AlunoCurso(28, 4),
                new AlunoCurso(29, 4),
                new AlunoCurso(30, 4),
                new AlunoCurso(31, 5),
                new AlunoCurso(32, 5),
                new AlunoCurso(33, 5),
                new AlunoCurso(34, 5),
                new AlunoCurso(35, 5),

            });



        }
        
    }
}

