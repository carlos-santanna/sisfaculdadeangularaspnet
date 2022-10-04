import { Disciplina } from "./disciplina.model"

export interface Curso{
  id?:number,
  nome:string,
  idsDisciplinas?:number[],
  disciplinas?:Disciplina[]
}

export interface CursoInfo{  
  curso: Curso,
  disciplinas: number,
  alunos: number,
  professores: number,
  media:number
}

export interface CursoDisciplina{
  id: number,
  nome:string,
  disciplinaId:number,
  professorId:number,
  professorNome:string
}

export interface CursoAluno{
  id: number,
  nome:string,
  alunoId:number,
  aluno:string,
  dtNascimento:string
}
