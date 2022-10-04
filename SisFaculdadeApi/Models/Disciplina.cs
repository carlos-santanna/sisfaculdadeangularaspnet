using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisFaculdadeApi.Models
{
    public class Disciplina
    {
        public Disciplina(){}
        public Disciplina(int id, string nome, int professorId) 
        {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;
   
        }
        public int Id { get; set; }

        [StringLength(200)]
        public string Nome{ get; set; }
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual ICollection<DisciplinaAluno> DisciplinasAlunos { get; set; }
        //public virtual ICollection<CursoDisciplina> CursosDisciplinas { get; set; }
    }
}