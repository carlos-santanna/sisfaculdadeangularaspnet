import { Component, OnInit, Input,OnChanges,SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder,Validators } from '@angular/forms';
import { lastValueFrom } from 'rxjs';
import { Aluno } from 'src/app/models/aluno.model';
import { Disciplina } from 'src/app/models/disciplina.model';
import { AlunoService } from 'src/app/servicos/aluno.service';
import { CursoService } from 'src/app/servicos/curso.service';
import { NotificationService } from 'src/app/servicos/notification.service';
import { DialogService } from './../../../../servicos/dialog.service';
import { Funcoes } from 'src/app/util/funcoes';
import * as moment from 'moment';
import { DataDBPipe, DataPipe } from 'src/app/pipes/data.pipe';
import { CustomValidationService } from 'src/app/servicos/custom-validation.service';

@Component({
  selector: 'app-criar-editar-aluno',
  templateUrl: './criar-editar-aluno.component.html',
  styleUrls: ['./criar-editar-aluno.component.css']
})
export class CriarEditarAlunoComponent implements OnInit, OnChanges {
  @Input() id?:number = 0;
  @Input() opened:boolean = false;
  
  objView:Aluno={
    id: 0,
    nome: '',
    idsCursos: [],
    dataNascimento: ''
  };

  lista_cursos?:Disciplina[];

  form: FormGroup = new FormGroup({

  });
  isFormReady = false;

  constructor(
    private dialog:DialogService, private notification:NotificationService
    ,private dadosService:AlunoService, private cursoService:CursoService
    ,private fb:FormBuilder
    ,private dataPipe:DataPipe
    ,private dataDBPipe:DataDBPipe
    ,private validacao:CustomValidationService
  ) {
   this.ajustaFormBuild();

   }



  async ngOnInit() {
    this.lista_cursos = await this.getCursos();
    this.isFormReady = true;
    this.id=0;

    
  }

  ngOnChanges(changes: SimpleChanges): void {        
    this.isFormReady = false;    
    if(changes['id']){
      if(changes['id'].currentValue>0 && this.opened===true){
        this.configura();
      }

    }else{
      this.id = 0;
      this.objView={
        id: 0,
        nome: '',
        idsCursos: [],
        dataNascimento: ''
      };
    }
    this.isFormReady = true;
  }

  ajustaFormBuild(){      
    
    this.form = this.fb.group({
      id: this.fb.control(this.objView.id),
      nome: this.fb.control(this.objView.nome,[Validators.required, Validators.min(3),Validators.max(150)]),
      dataNascimento: this.fb.control(this.objView.dataNascimento? moment(this.dataPipe.transform(this.objView.dataNascimento ),
       'DD/MM/YYYY') : '', { validators: [Validators.required, this.validacao.data()], updateOn: 'blur' })
      ,cursos: this.fb.control(this.objView.idsCursos,[Validators.required])
    });
  }

  async configura(){
    //this.dialog.abrir();

    this.isFormReady = false;

    setTimeout(() => {
      //dá uma pausa para poder abrir a animação
    },550);

    if(this.id){
      this.objView.id = this.id
    }
    if(this.objView.id){
      this.objView = await this.getDadosById(this.objView.id);
    }
    
    
   this.ajustaFormBuild();

    this.isFormReady = true;
    this.dialog.close();
  }
  async getDadosById(id:number){
    const p$ = this.dadosService.getById(id);
    let obj:any = await lastValueFrom(p$)
    obj.idsCursos = [];
    const arrCursos = obj.alunosCursos
    if(arrCursos){
      for(let icd in arrCursos){
        let objCd = arrCursos[icd]??0
        if(!objCd){
          continue;
        }
        
        if(objCd['alunoId'] && objCd['cursoId']){
          obj.idsCursos.push(objCd['cursoId']);
        }
      }
    }
    return obj;
  }
  async getCursos(){
    const p$ = this.cursoService.lista();
    let cursos:any[]= await lastValueFrom(p$)
    return cursos;
  }

  onSubmit(): boolean{
    if(this.form.invalid){
      return false;
    }
    let objViewCopia:any = {};
    objViewCopia= Object.assign(objViewCopia,this.form.value);

    this.dialog.abrir();
    if(this.objView.id){
      return this.atualizar(objViewCopia.id,objViewCopia);
    }else{
      return this.criar(objViewCopia);
    }
  }

  atualizar(id:number,objView:Aluno):boolean{
    if(!id || !objView) {
      return false;
    }

    //remove alguma opções da conta
    this.dadosService.atualizar(id,objView)
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
    return true;
  }

  criar(objView:Aluno):boolean{
    if(!objView) {
      return false;
    }
    this.dadosService.criar(objView)
    .subscribe({
      next: (res:any) =>{
        let fnt = new Funcoes();

        let callback_sucesso = ()=>{
          // this._location.back();
        }
        
        if(res.id){
          this.id = res.id;

          this.objView.id = res.id;
          
          this.notification.notify('Sucesso! Operação realizada');
          setTimeout(()=>{
            window.location.href = window.location.href
          },1500)
        }else{
          this.notification.notify('Erro ao efetuar a operação');          
        }
        this.dialog.close();
        
        

        
        return true;
      },
      error: (e:any)=>{
        this.dialog.close();
        this.notification.notify(`Falha ao tentar efetuar a operação: ${e}`);
      }
    });
    return true;
  }

  teste(){
    console.log(this.form.controls)
  }
}
