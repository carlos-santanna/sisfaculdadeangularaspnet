import { Injectable } from '@angular/core';
import { Curso, CursoAluno, CursoInfo } from '../models/curso.model';
import { environment } from 'src/environments/environment';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NotificationService } from './notification.service';
import { Observable, throwError } from 'rxjs';
import { DialogService } from './dialog.service';
import { CursoDisciplina } from '../models/curso-disciplina.model';
import { DisciplinaCurso } from '../models/disciplina.model';


@Injectable({
  providedIn: 'root'
})
export class CursoService {

  constructor(private http:HttpClient, private notificationService:NotificationService, private dialog:DialogService) { }

  lista():Observable<Curso[]>{

    let url:string = `${environment.API_URL}curso`

    return this.http.get<Curso[]>(url)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }

  listaDisciplinasCurso(id:number):Observable<DisciplinaCurso[]>{

    let url:string = `${environment.API_URL}curso/${id}/disciplinas`

    return this.http.get<DisciplinaCurso[]>(url)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }

  remover(id:number):Observable<any>{
    let url:string = `${environment.API_URL}curso/${id}`

    const options = {
      headers: new HttpHeaders({
          'Content-Type': 'application/json'
      })
  }
  
    return this.http.delete<any>(url,options)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }

  //remove as disciplinas do curso
  removerDisciplinas(id:number):Observable<any>{
    let url:string = `${environment.API_URL}curso/${id}/remover/disciplinas`

    return this.http.delete<any>(url)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }


  criar(curso:Curso):Observable<any>{
    let url:string = `${environment.API_URL}curso`

    return this.http.post<any>(url,curso)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }

  //insere as disciplinas do curso
  criarCursoDisciplina(cursoDisciplinas:CursoDisciplina[]):Observable<any>{
    let url:string = `${environment.API_URL}curso/disciplinas`

    return this.http.post<any>(url,cursoDisciplinas)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }

  atualizar(id:number,curso:Curso):Observable<any>{
    let url:string = `${environment.API_URL}curso/${id}`

    return this.http.put<any>(url,curso)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }


  getById(id:number):Observable<Curso>{

    let url:string = `${environment.API_URL}curso/${id}`

    return this.http.get<Curso>(url)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }


  listaResumo():Observable<CursoInfo[]>{

    let url:string = `${environment.API_URL}curso/resumo`

    return this.http.get<CursoInfo[]>(url)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }

  listaCursoDisciplina(id:number):Observable<CursoDisciplina[]>{

    let url:string = `${environment.API_URL}curso/${id}/disciplinas`

    return this.http.get<CursoDisciplina[]>(url)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }

  listaCursoAlunos(id:number):Observable<CursoAluno[]>{

    let url:string = `${environment.API_URL}curso/${id}/alunos`

    return this.http.get<CursoAluno[]>(url)
    .pipe(
      map(res => {
            return res;
          }
      )
      ,catchError(err =>{
        this.notificationService.notify(`Erro ${err.status} ${err.message}`)
        return throwError(err)
      })
    )
  }

}
