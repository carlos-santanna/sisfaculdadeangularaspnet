using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SisFaculdadeApi.RequestsModels
{
    public class CursoRequest
    {
        [Required]
        [StringLength(200)]
        public string nome { get; set; }

        public int[]? disciplinas { get; set; }

    }
}
