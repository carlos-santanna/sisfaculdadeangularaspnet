using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SisFaculdadeApi.Models
{
    public class Professor
    {
        public Professor() { }
        public Professor(int id, string nome, DateTime dataNascimento, double salario)
        {
            this.Id = id;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Salario = salario;            
        }

        public int Id { get; set; }

        [StringLength(150)]
        public string Nome{ get; set; }
        public DateTime DataNascimento { get; set; }
        public double Salario { get; set; }

        [JsonIgnore]
        public virtual ICollection<Disciplina> Disciplinas { get; set; }
    }
}