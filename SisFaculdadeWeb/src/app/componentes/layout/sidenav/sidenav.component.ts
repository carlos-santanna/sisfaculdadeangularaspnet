import { environment } from 'src/environments/environment';
import { MatSidenav } from '@angular/material/sidenav';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';
import { delay, filter } from 'rxjs/operators';
import { NavigationEnd, Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { PanelMenu } from 'primeng/panelmenu';
import {ScrollingModule} from '@angular/cdk/scrolling';
import { SidenavService } from 'src/app/servicos/sidenav.service';
import { LocalStorageService } from 'src/app/servicos/local-storage.service';

import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
@UntilDestroy()
@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit, AfterViewInit {
  softwareVersion:string =  environment.versao;
  isShowing:boolean=false;
  logged: boolean = false;


  events: string[] = [];
  opened: boolean = false;
  showMenu = false;

  //variavel que contra a sidenav
  podeAbrirSideNav = true;
  iniciaSideBarAberta = true;
  
  items?: MenuItem[];
  items2?: MenuItem[];

  

  corHeader:string = environment.COR_PRINCIPAL??'';

  constructor(
     private breakPointObserver:BreakpointObserver,
     private el:ElementRef,
     private router: Router     
     ,private sideNavService: SidenavService
     ,private localStorage: LocalStorageService
     ) {
      this.iniciaSideBarAberta = this.getStatusNavLocalStorage();
     }
  @ViewChild(MatSidenav) sidenav!:MatSidenav;

  @ViewChild(PanelMenu) panelMenu!:PanelMenu;

  ngOnInit(): void {



    
    
    

    this.items = [
      {
        label: 'Página Inicial',
        icon:'fas fa-home'
        ,routerLink: ['/']
      },
      {
        label: 'Cursos',
        icon:'fas fa-book'
        ,routerLink: ['/admin/cursos']
      },
      {
        label: 'Disciplinas',
        icon:'fas fa-bookmark'
        ,routerLink: ['/admin/disciplina']
      },
      {
        label: 'Professores',
        icon:'fas fa-user'
        ,routerLink: ['/admin/professor']
      },
      {
        label: 'Alunos',
        icon:'fas fa-user'
        ,routerLink: ['/admin/alunos']
      }
  ]

    this.sideNavService.messageSideNav.subscribe((message)=>{

      if(message=='toggle'){
        this.toogleSideNav();
      }else if(message=='hide'){
        this.hideSideNav();
      }else{
        this.showSideNav();
      }
      this.statusSideNav(this.sidenav?.opened?true:false);
    });


    this.statusSideNav(this.iniciaSideBarAberta);

  }


  statusSideNav(st:boolean = false){
    this.sideNavService.statusSideNav(st?'hide':'opened');

  }

  toogleSideNav(op?:boolean){
    if(!this.podeAbrirSideNav){
      this.isShowing = false;
    }else{
      this.isShowing = !this.isShowing;
      if(op===true){
        this.sidenav.opened = true;
      }else if(op===false){
        this.sidenav.opened = false;
      }else{
        this.sidenav.toggle()
      }

    }
    this.localStorage.set('sidenav',this.sidenav.opened?'opened':'hide');
  }

  hideSideNav(){
      this.isShowing = false;
  }

  showSideNav(){
    if(this.podeAbrirSideNav){
      this.isShowing = true;
    }
  }

  // ngAfterViewInit(): void{
    // um observador para ficar vendo se houve mudança do tamanho da tela
    // this.breakPointObserver.observe(['(max-width: 800px)']).subscribe((res)=>{
    //   if(res.matches){
    //     this.sidenav.mode = 'over';
    //     this.isShowing = false;

    //   }else{
    //     this.sidenav.mode = 'side';
    //     this.isShowing = true;
    //   }
    // })
  // }

  ngAfterViewInit() {

    this.breakPointObserver
      .observe(['(max-width: 800px)'])
      .pipe(delay(1), untilDestroyed(this))
      .subscribe((res) => {
        if (res.matches) {
          this.sidenav.mode = 'over';
          this.toogleSideNav(false);
        } else {
          this.sidenav.mode = 'side';

        }
      });

    this.router.events
      .pipe(
        untilDestroyed(this),
        filter((e) => e instanceof NavigationEnd)
      )
      .subscribe(() => {
        if (this.sidenav.mode === 'over') {
          this.toogleSideNav(false);
        }
      });
  }

  toggleMenu(op:string='') {
      this.showMenu = !this.showMenu;
  }

  toggleSubMenu(op:string=''){
    let objGrupo = this.el.nativeElement.querySelector('.grupoMenu[data-item="'+op+'"]');



    let obj = objGrupo.querySelector('[data-item="'+op+'"]');
    if(obj.style.display!=='none'){
      obj.style.display='none'
      objGrupo.querySelector('.icon-up').style.display='block';
      objGrupo.querySelector('.icon-right').style.display='none';
    }else{
      obj.style.display='block'
      objGrupo.querySelector('.icon-up').style.display='none';
      objGrupo.querySelector('.icon-right').style.display='block';
    }


  }


  getStatusNavLocalStorage():boolean{
    let res = true;

    let ops = this.localStorage.get('sidenav');
    if(ops===null || ops==='opened'){
      res = true;
    }else{
      res = false;
    }

    return res;
  }


  getIniciaisUserLoggeding():string{
    let iniciais:string = '';
    let nome:string = 'Usuário Sistema';
    if(nome){
      nome = nome.replace(new RegExp(/ de /),' ');
      nome = nome.replace(new RegExp(/ da /),' ');
      nome = nome.replace(new RegExp(/ das /),' ');
      nome = nome.replace(new RegExp(/ dos /),' ');
      let arr = nome.split(' ');
      if(arr){
        iniciais = arr[0]?arr[0].substring(0,1):'';
        if(arr.length>1){
         iniciais+= arr[1]?arr[1].substring(0,1):'';
        }
      }
    }
    return iniciais;
 }

 getPrimeiroNomeUsuarioLoggedin():string{

  let nome:string = 'Usuário'
  return nome;
}

logout(){
  console.log('Desloga o usuário')
}





}
