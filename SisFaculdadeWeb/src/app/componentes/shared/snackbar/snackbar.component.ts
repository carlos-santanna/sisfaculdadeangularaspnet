import { Component, OnInit } from '@angular/core';
import { NotificationService } from 'src/app/servicos/notification.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-snackbar',
  templateUrl: './snackbar.component.html',
  styleUrls: ['./snackbar.component.css']
})
export class SnackbarComponent implements OnInit {
  msg:string = '';
  duracaoEmSegundos:number = 5;
  constructor(private snackBar: MatSnackBar,private notificacao: NotificationService) { }

  ngOnInit(): void {
    this.notificacao.notifier.subscribe(message=>{
      this.msg = message;
      this.mostrar(this.msg);
    })
  }

  mostrar(msg:string, btnAct5ion:string=''){    
    this.snackBar.open(msg,btnAct5ion,{
      duration: this.duracaoEmSegundos * 1000
    })
  }

}
