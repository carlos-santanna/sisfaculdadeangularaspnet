import { Curso } from "./curso.model"

export interface Aluno{
  id?:number,
  nome:string,
  dataNascimento:string,
  cursoId?:number,
  idsCursos?:number[]
  alunosCursos?:any[]
}
