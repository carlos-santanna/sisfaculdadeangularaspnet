using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisFaculdadeApi.Models
{
    public class DisciplinaAluno
    {
        public DisciplinaAluno(){}
        public DisciplinaAluno(int alunoId, int disciplinaId, int cursoId,double nota) 
        {
            this.DisciplinaId = disciplinaId;
            this.AlunoId = alunoId;
            this.Nota = nota;
            this.CursoId = cursoId;

        }

        public DisciplinaAluno(int alunoId, int disciplinaId, int cursoId)
        {
            this.DisciplinaId = disciplinaId;
            this.AlunoId = alunoId;
            this.CursoId = cursoId;

        }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina {get; set;}
        public int AlunoId { get; set; }   
        public Aluno Aluno {get; set;}     
        public double? Nota { get; set; }

        public int CursoId { get; set; }

        public virtual Curso Curso { get; set; }
    }
}