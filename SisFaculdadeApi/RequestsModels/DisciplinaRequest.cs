using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SisFaculdadeApi.RequestsModels
{
    public class DisciplinaRequest
    {
        [Required]
        [StringLength(200)]
        public string nome { get; set; }
        [Required]
        public int professorId { get; set; }
       
    }
}
