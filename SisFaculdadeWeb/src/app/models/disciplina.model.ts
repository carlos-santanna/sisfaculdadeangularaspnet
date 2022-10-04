export interface Disciplina{
  id?:number,
  nome:string,
  professorId:number
}

export interface DisciplinaInfo{
  disciplina: Disciplina,
  cursos: number,
  alunos: number,
  professores: number,
  media:number
}

export interface DisciplinaAluno{
  id: number,
  nome:string,
  cursoId:number,
  curso:string,
  alunoId:number,
  aluno:string,
  dtNascimento:string,
  nota:number
}

export interface DisciplinaCurso{
  disciplina: any,
  alunos: number,
  media: number
}
