import { Injectable } from '@angular/core';
import { Aluno} from '../models/aluno.model';
import { environment } from 'src/environments/environment';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NotificationService } from './notification.service';
import { Observable, throwError } from 'rxjs';
import { DialogService } from './dialog.service';
import { Disciplina } from '../models/disciplina.model';
import { AlunoDisciplina } from '../models/aluno-disciplina.model';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  constructor(private http:HttpClient, private notificationService:NotificationService, private dialog:DialogService) { }

  lista():Observable<Aluno[]>{

    let url:string = `${environment.API_URL}aluno`

    return this.http.get<Aluno[]>(url)
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
    let url:string = `${environment.API_URL}aluno/${id}`
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


  criar(aluno:Aluno):Observable<any>{
    let url:string = `${environment.API_URL}aluno`

    return this.http.post<any>(url,aluno)
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

  atualizar(id:number,aluno:Aluno):Observable<any>{
    let url:string = `${environment.API_URL}aluno/${id}`

    return this.http.put<any>(url,aluno)
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


  atualizarNota(obj:any):Observable<any>{
    let url:string = `${environment.API_URL}aluno/atualizar/nota`
    const options = {
      headers: new HttpHeaders({
          'Content-Type': 'application/json'
      })
  }
    return this.http.put<any>(url,obj,options)
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


  getById(id:number):Observable<Aluno>{

    let url:string = `${environment.API_URL}aluno/${id}`

    return this.http.get<Aluno>(url)
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

  //obtem o aluno e as disciplinas em que ele ministra aulas
  listaDisciplina(id:number):Observable<AlunoDisciplina[]>{

    let url:string = `${environment.API_URL}aluno/${id}/disciplinas`

    return this.http.get<AlunoDisciplina[]>(url)
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
