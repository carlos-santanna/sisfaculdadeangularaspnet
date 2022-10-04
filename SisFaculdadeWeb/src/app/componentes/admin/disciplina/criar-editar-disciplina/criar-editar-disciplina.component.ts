import { Component, OnInit, Input,OnChanges,SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder,Validators } from '@angular/forms';
import { lastValueFrom } from 'rxjs';
import { Professor } from 'src/app/models/professor.model';
import { Disciplina } from 'src/app/models/disciplina.model';
import { ProfessorService } from 'src/app/servicos/professor.service';
import { DisciplinaService } from 'src/app/servicos/disciplina.service';
import { NotificationService } from 'src/app/servicos/notification.service';
import { DialogService } from './../../../../servicos/dialog.service';
import { Funcoes } from 'src/app/util/funcoes';

@Component({
  selector: 'app-criar-editar-disciplina',
  templateUrl: './criar-editar-disciplina.component.html',
  styleUrls: ['./criar-editar-disciplina.component.css']
})
export class CriarEditarDisciplinaComponent implements OnInit, OnChanges {
  @Input() id?:number = 0;
  @Input() opened:boolean = false;
  objView:Disciplina={
    id: 0,
    nome: '',
    professorId: 0
  };

  lista_professores?:Professor[];

  form: FormGroup = new FormGroup({

  });
  isFormReady = false;

  constructor(
    private dialog:DialogService, private notification:NotificationService
    ,private dadosService:DisciplinaService, private disciplinaService:DisciplinaService, private professorService: ProfessorService
    ,private fb:FormBuilder
  ) {
   this.ajustaFormBuild();

   }



  async ngOnInit() {
    this.lista_professores = await this.getProfessores();
    this.isFormReady = true;
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.isFormReady = false;

    if(changes['id']){
      if(changes['id'].currentValue>0 && this.opened===true){
        this.configura();
      }

    }
    this.isFormReady = true;
  }

  ajustaFormBuild(){
    this.form = this.fb.group({
      id: this.fb.control(this.objView.id),
      nome: this.fb.control(this.objView.nome,[Validators.required, Validators.min(3),Validators.max(150)]),
      professorId: this.fb.control(this.objView.professorId,[Validators.required, Validators.min(1)])
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
    return obj;
  }
  async getProfessores(){
    const p$ = this.professorService.lista();
    let professores:any[]= await lastValueFrom(p$)
    return professores;
  }

  onSubmit(): boolean{
    if(this.form.invalid){
      return false;
    }
    this.objView= Object.assign(this.objView,this.form.value);

    this.dialog.abrir();
    if(this.objView.id){
      return this.atualizar(this.objView.id,this.objView);
    }else{
      return this.criar(this.objView);
    }
  }

  atualizar(id:number,objView:Disciplina):boolean{
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

  criar(objView:Disciplina):boolean{
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
          this.ajustaFormBuild();
          this.notification.notify('Sucesso! Operação realizada');
        }else{
          this.notification.notify('Erro ao efetuar a operação');          
        }
        this.dialog.close();
        
        console.log(res)

        
        return true;
      },
      error: (e:any)=>{
        this.dialog.close();
        this.notification.notify(`Falha ao tentar efetuar a operação: ${e}`);
      }
    });
    return true;
  }
}
