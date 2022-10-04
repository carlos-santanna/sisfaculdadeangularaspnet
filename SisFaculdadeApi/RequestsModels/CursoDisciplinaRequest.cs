using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SisFaculdadeApi.RequestsModels
{
    public class CursoDisciplinaRequest
    {
        [Required]        
        public int cursoId { get; set; }
        [Required]
        public int disciplinaId { get; set; }
       
    }
}
