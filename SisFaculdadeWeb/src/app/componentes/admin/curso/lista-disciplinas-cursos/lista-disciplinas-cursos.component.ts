import { Component, Input, OnChanges, OnInit, SimpleChanges, ViewChild} from '@angular/core';
import { Table } from 'primeng/table';
import { Curso, CursoInfo } from 'src/app/models/curso.model';
import { Funcoes } from 'src/app/util/funcoes';
import { NotificationService } from 'src/app/servicos/notification.service';
import { CursoService } from 'src/app/servicos/curso.service';
import { DialogService } from 'src/app/servicos/dialog.service';
import { lastValueFrom } from 'rxjs';
import { DisciplinaCurso } from 'src/app/models/disciplina.model';

@Component({
  selector: 'app-lista-disciplinas-curso',
  templateUrl: './lista-disciplinas-curso.component.html',
  styleUrls: ['./lista-disciplinas-curso.component.css']
})
export class ListaDisciplinasCursoComponent implements OnInit, OnChanges {
  loading: boolean = true;
  listaItems:DisciplinaCurso[] = [];
  @Input() idSelected:number = 0;  
  @Input() nomeCurso:string = '';
  @Input() opened:boolean = false;
  
  @ViewChild('dt') table?:Table;
  isFormReady = false;

  constructor(private dadosService:CursoService) { }

  
  async ngOnChanges(changes: SimpleChanges) {        
    this.isFormReady = false;    
    console.log(changes)
    if(changes['idSelected']){
      if(changes['idSelected'].currentValue>0 && this.opened===true){
        this.idSelected = changes['id'].currentValue
        await this.getDados();   
      }

    }
    this.isFormReady = true;
  }

  async getDados(){
    if(this.idSelected){
      if(this.idSelected>0){
        this.dadosService.listaDisciplinasCurso(this.idSelected).subscribe({
          next: (res) =>{
            console.log(res)
            this.listaItems = res;
            this.loading = false;          
          },
          error: (e) =>{
            console.log('Não foi possível obter os itens',e)
          }
        });
      }
    }
  }
  
  async ngOnInit() {
    
  }

  
  

}
