import { Injectable } from '@angular/core';
import { Disciplina, DisciplinaAluno, DisciplinaInfo } from '../models/disciplina.model';
import { environment } from 'src/environments/environment';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NotificationService } from './notification.service';
import { Observable, throwError } from 'rxjs';
import { DialogService } from './dialog.service';


@Injectable({
  providedIn: 'root'
})
export class DisciplinaService {

  constructor(private http:HttpClient, private notificationService:NotificationService, private dialog:DialogService) { }

  lista():Observable<Disciplina[]>{

    let url:string = `${environment.API_URL}disciplina`

    return this.http.get<Disciplina[]>(url)
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
    let url:string = `${environment.API_URL}disciplina/${id}`
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


  criar(disciplina:Disciplina):Observable<any>{
    let url:string = `${environment.API_URL}disciplina`

    return this.http.post<any>(url,disciplina)
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

  atualizar(id:number,disciplina:Disciplina):Observable<any>{
    let url:string = `${environment.API_URL}disciplina/${id}`

    return this.http.put<any>(url,disciplina)
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


  getById(id:number):Observable<Disciplina>{

    let url:string = `${environment.API_URL}disciplina/${id}`

    return this.http.get<Disciplina>(url)
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


  listaResumo():Observable<DisciplinaInfo[]>{

    let url:string = `${environment.API_URL}disciplina/resumo`

    return this.http.get<DisciplinaInfo[]>(url)
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

  listaDisciplinaAlunos(id:number):Observable<DisciplinaAluno[]>{

    let url:string = `${environment.API_URL}disciplina/${id}/alunos`

    return this.http.get<DisciplinaAluno[]>(url)
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

  listaDisciplinaCursoAlunos(idDisciplina:number, idCurso:number):Observable<DisciplinaAluno[]>{

    let url:string = `${environment.API_URL}disciplina/${idDisciplina}/${idCurso}/alunos`

    return this.http.get<DisciplinaAluno[]>(url)
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
