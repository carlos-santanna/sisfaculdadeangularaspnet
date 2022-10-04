using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisFaculdadeApi.Models
{
    public class Curso
    {
        public Curso(){}
        public Curso(int id, string nome) 
        {
            this.Id = id;
            this.Nome = nome;
   
        }
        public int Id { get; set; }
        [StringLength(200)]
        public string Nome{ get; set; }
        public virtual ICollection<CursoDisciplina> CursosDisciplinas { get; set; }

        public virtual ICollection<AlunoCurso> AlunosCursos { get; set; }
    }
}