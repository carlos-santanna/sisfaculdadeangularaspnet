namespace SisFaculdadeApi.Models
{
    public class AlunoCurso
    {   
        public AlunoCurso() { }
        public AlunoCurso(int alunoId, int cursoId)
        {
            AlunoId = alunoId;            
            CursoId = cursoId;            
        }

        public int AlunoId { get; set; }        
        public int CursoId { get; set; }
        
      
    }
}

