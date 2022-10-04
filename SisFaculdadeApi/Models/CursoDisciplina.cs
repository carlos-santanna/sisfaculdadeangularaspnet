using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisFaculdadeApi.Models
{
    public class CursoDisciplina
    {
        public CursoDisciplina(){}
        public CursoDisciplina(int cursoId, int disciplinaId) 
        {
            this.CursoId = cursoId;
            this.DisciplinaId = disciplinaId;
   
        }
        public int CursoId { get; set; }    
        //public Curso Curso {get; set;}
        public int DisciplinaId { get; set; }
        public virtual Disciplina Disciplina {get; set;}
    }
}