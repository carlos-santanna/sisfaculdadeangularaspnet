using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisFaculdadeApi.Models
{
    public class Aluno
    {
        public Aluno(){}
        public Aluno(int id, DateTime dataNascimento, string nome) 
        {
            this.Id = id;
            this.DataNascimento = dataNascimento;
            this.Nome = nome;
   
        }
        public int Id { get; set; }        
        public DateTime DataNascimento { get; set; }
        [StringLength(150)]
        public string Nome { get; set; }
        public virtual ICollection<DisciplinaAluno> DisciplinasAlunos { get; set; }

        public virtual ICollection<AlunoCurso> AlunosCursos { get; set; }
    }
}