using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SisFaculdadeApi.RequestsModels
{
    public class AlunoRequest
    {
        [Required]
        [StringLength(150)]
        public string nome { get; set; }
        [Required]
        public DateTime dataNascimento { get; set; }

        [Required]
        public int cursoId { get; set; }
        public int[]? cursos { get; set; }
    }
}
