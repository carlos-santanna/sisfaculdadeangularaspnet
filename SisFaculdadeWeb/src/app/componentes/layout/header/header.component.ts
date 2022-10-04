import { environment } from 'src/environments/environment';
import { Component, AfterViewInit, ViewChild, Input } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { MatSidenav } from '@angular/material/sidenav';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { SidenavService } from 'src/app/servicos/sidenav.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  showFiller = false;

  sidenavIsOpened:string = '';

  podeLogar: boolean = true;

  subtitulo_pagina:string = '';
  titulo_pagina:string = environment.TITULO_SISTEMA;

  isLoggedIn = false;

  colorHeader:string = 'primary';
  @Input() corHeader:string = environment.COR_PRINCIPAL??'';
  showSubtitulo:boolean = false;

  constructor(private breakpointObserver: BreakpointObserver,
    private sideNavService:SidenavService,          
     private router:Router) {}

    showSubTitulo = true;


    abreOuFechaSideBar(){
      this.sideNavService.messageSideNav.next('toggle');
    }

    ngOnInit() {
     
      this.sideNavService.messageSideNavStatus.subscribe((tp:any)=>{
        this.sidenavIsOpened = tp;
      });
    }


  ngAfterViewInit(): void{
    //um observador para ficar vendo se houve mudança do tamanho da tela
    this.breakpointObserver.observe(['(max-width: 800px)'])
    .subscribe((res)=>{
     ////tem que ocultar a área do subtitulo
    })
  }

  logout(){
   console.log('efetua logout')
  }

  goToAlteraSenha(){
    console.log('alterar senha')
  }

  getIniciaisUserLoggeding():string{
     let iniciais:string = '';
     let nome:string = 'Usuário Sistema'
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

}
