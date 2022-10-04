using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SisFaculdadeApi.RequestsModels
{
    public class CursoDisciplinaNotasRequest
    {
        [Required]        
        public int cursoId { get; set; }
        [Required]
        public int disciplinaId { get; set; }
        [Required]
        public int alunoId { get; set; }
        [Required]
        public double nota { get; set; }

    }
}
