import { Injectable } from '@angular/core';
import { Professor} from '../models/professor.model';
import { environment } from 'src/environments/environment';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NotificationService } from './notification.service';
import { Observable, throwError } from 'rxjs';
import { DialogService } from './dialog.service';
import { Disciplina } from '../models/disciplina.model';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {

  constructor(private http:HttpClient, private notificationService:NotificationService, private dialog:DialogService) { }

  lista():Observable<Professor[]>{

    let url:string = `${environment.API_URL}professor`

    return this.http.get<Professor[]>(url)
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
    let url:string = `${environment.API_URL}professor/${id}`
    
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


  criar(professor:Professor):Observable<any>{
    let url:string = `${environment.API_URL}professor`

    return this.http.post<any>(url,professor)
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

  atualizar(id:number,professor:Professor):Observable<any>{
    let url:string = `${environment.API_URL}professor/${id}`

    return this.http.put<any>(url,professor)
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


  getById(id:number):Observable<Professor>{

    let url:string = `${environment.API_URL}professor/${id}`

    return this.http.get<Professor>(url)
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

  //obtem as disciplinas em que o professor ministra aulas
  listaProfessorDisciplina(id:number):Observable<Disciplina[]>{

    let url:string = `${environment.API_URL}professor/${id}/disciplinas`

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

}
