import { Component, Input, OnChanges, OnInit, SimpleChanges, ViewChild} from '@angular/core';
import { Table } from 'primeng/table';

import { Funcoes } from 'src/app/util/funcoes';
import { NotificationService } from 'src/app/servicos/notification.service';
import { AlunoService } from 'src/app/servicos/aluno.service';
import { DialogService } from 'src/app/servicos/dialog.service';
import { lastValueFrom } from 'rxjs';

import { AlunoDisciplina } from 'src/app/models/aluno-disciplina.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-lista-disciplinas-aluno',
  templateUrl: './lista-disciplinas-aluno.component.html',
  styleUrls: ['./lista-disciplinas-aluno.component.css']
})
export class ListaDisciplinasAlunoComponent implements OnInit, OnChanges {
  loading: boolean = true;
  listaItems:AlunoDisciplina[] = [];
  @Input() idSelected:number = 0;  
  @Input() nomeAluno:string = '';
  @Input() opened:boolean = false;
  
  @ViewChild('dt') table?:Table;
  isFormReady = false;

  @Input() nomeCurso:string = '';
  idCursoSelected:number = 0;
  idDisciplinaSelected:number = 0;
  nota:number = 0;
  
  
  

  form: FormGroup = new FormGroup({

  });

  constructor(private dadosService:AlunoService,private fb:FormBuilder, private notification:NotificationService, private dialog:DialogService) { 

    this.form = this.fb.group({
      alunoId: this.fb.control(this.idSelected),
      cursoId: this.fb.control(this.idCursoSelected,[Validators.required, Validators.min(1)]),
      disciplinaId: this.fb.control(this.idDisciplinaSelected,[Validators.required,Validators.min(1)]),
      nota: this.fb.control('',[Validators.required,Validators.min(0.0)])
    });
  }

  
  async ngOnChanges(changes: SimpleChanges) {        
    this.isFormReady = false;    
    console.log(changes)
    if(changes['idSelected']){
      if(changes['idSelected'].currentValue>0 && this.opened===true){
        this.idSelected = changes['idSelected'].currentValue
        await this.getDados();   
      }

    }
    this.isFormReady = true;
  }

  async getDados(){
    if(this.idSelected){
      if(this.idSelected>0){
        this.dadosService.listaDisciplina(this.idSelected).subscribe({
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


  async gravaInfoNota(){
    if(this.listaItems){
      let newObj = [];
      for(let ob of this.listaItems){
        let cursoId:any = ob['cursoId']??0;
        let alunoId:any = ob['alunoId']??0;
        let disciplinaId:any = ob['disciplinaId']??0;
        let nota:any = ob['nota']??'0';
        nota = typeof nota=='string'?parseFloat(nota):nota;

        if(!cursoId || !disciplinaId || !alunoId)
          continue;
        
        newObj.push({
          cursoId: cursoId,
          disciplinaId: disciplinaId,
          alunoId: alunoId,
          nota:nota
        })
        
      }
      if(newObj.length>0){
        let sob = {
          "arrNotas": newObj
        }
        this.dadosService.atualizarNota(newObj)
        .subscribe({
          next: (res:any) =>{
            let fnt = new Funcoes();

            let callback_sucesso = ()=>{
              // this._location.back();
              //this.cancelaOperacao()
            }
            
            if(res){
              this.notification.notify('Erro ao efetuar a operação');
            }else{
              this.notification.notify('Sucesso! Operação realizada');

              setTimeout(()=>{
                window.location.href = window.location.href;
              },1500)
            }
            this.dialog.close();
            setTimeout(() => {
              let dlg = res?res:undefined;
              if(dlg){
                this.dialog.dialog(dlg);
              }
            },320)

            return true;
          },
          error: (e: any)=>{
            this.dialog.close();
            this.notification.notify(`Falha ao tentar efetuar a operação: ${e}`);
          }
        });  
      }
    }
  }

  
  

}
