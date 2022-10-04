import { Component, OnInit, ViewChild} from '@angular/core';
import { Table } from 'primeng/table';
import { Curso, CursoInfo } from 'src/app/models/curso.model';
import { Funcoes } from 'src/app/util/funcoes';
import { NotificationService } from 'src/app/servicos/notification.service';
import { CursoService } from 'src/app/servicos/curso.service';
import { DialogService } from 'src/app/servicos/dialog.service';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-lista-disciplinas-cursos',
  templateUrl: './lista-disciplinas-cursos.component.html',
  styleUrls: ['./lista-disciplinas-cursos.component.css']
})
export class ListaDisciplinasCursosComponent implements OnInit {
  loading: boolean = true;
  listaItems:CursoInfo[] = [];
  idSelected:number = 0;
  showModal:boolean = false;
  showModalListaDisciplinas:boolean = false;
  showModalListaAlunos:boolean = false;


  @ViewChild('dt') table?:Table;

  constructor(private dadosService:CursoService,private notification:NotificationService, private dialog: DialogService) { }

  totalRecords:number = 0;

  async ngOnInit() {
    this.dadosService.listaResumo().subscribe({
      next: (res) =>{
        this.listaItems = res;
        this.loading = false;
        this.totalRecords = res.length??0;
      },
      error: (e) =>{
        console.log('Não foi possível obter os itens',e)
      }
    });
  }

  criarEditar(item:Curso | undefined = undefined):void{

    //objeto vazio
      if(item){
        this.idSelected = item['id']??0
      }else{
        this.idSelected = 0;
      }

      this.showModal = true;
  }

  
  listarDisciplinas(id:number):void{

    //objeto vazio
      if(id>0){
        this.idSelected = id;
        this.showModal = false;
        this.showModalListaAlunos = false;
        this.showModalListaDisciplinas = true;
      }else{
        this.idSelected = 0;
        this.showModal = false;
        this.showModalListaAlunos = false;
        this.showModalListaDisciplinas = false;
      }
  }

  listarAlunosDoCurso(id:number):void{

    //objeto vazio
      if(id>0){
        this.idSelected = id;
        this.showModal = false;
        this.showModalListaAlunos = true;
        this.showModalListaDisciplinas = false;
      }else{
        //this.idSelected = 0;
        this.showModal = false;
        this.showModalListaAlunos = false;
        this.showModalListaDisciplinas = false;
      }
  }

  hideModal(){
    this.idSelected = 0;
    this.showModal = false;
    this.showModalListaAlunos = false;
    this.showModalListaDisciplinas = false;
  }

  async perguntaSeRemover(id:number){
    
    this.dialog.show('<h4>Deseja mesmo remover o item selecionado? Ele será removido do banco de dados e '+
    'suas informações serão perdidas.</h4><br>',
    'Remover',false,true,()=>{},false,{
      'nome':'Continuar',
      'callback':async ()=>{
       await this.remover(id);
       this.reLoad();
      }
    })
  }

  async remover(idU:number){
    const p$ = this.dadosService.remover(idU);
    let res:any= await lastValueFrom(p$);

    let fnt = new Funcoes();
    let arr_res:any =fnt.trataErro(res,'','liErro');
    let cod = arr_res.cod?arr_res.cod:0;
    let msg = arr_res.msg?arr_res.msg:'';
    let tit = '';
    let txt = '';
    let callback_0 = undefined;
    if(cod<=0 ){
      tit='Erro ao tentar remover o item selecionado';
      msg ='<h4><i class="fas fa-thumbs-up text-danger"></i>&nbsp;Não foi possível efetuar a operação.</h4>'+
      (msg!=''?'<ul>'+msg+'</ul>':'');
      this.notification.notify('Erro ao efetuar a operação');
    }else{
      tit='Operação efetuada com sucesso!';
      msg ='<h4 class="tituloSucesso"><i class="fas fa-thumbs-up text-success"></i>&nbsp;'+
      '<h4>O usuário foi atualizado com sucesso!.</h4><br><br>';
      this.notification.notify('Sucesso! Operação realizada');
      callback_0 = ()=>{
        this.reLoad();
      }
    }

  }

  reLoad(){
    this.ngOnInit();
  }
  

}
