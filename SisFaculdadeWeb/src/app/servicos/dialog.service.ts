import { Injectable, EventEmitter } from '@angular/core';
import { Dialog } from '../models/dialog.model';

@Injectable({
  providedIn: 'root'
})
export class DialogService {
  dialoger = new EventEmitter<Dialog>();
  dialogerClose = new EventEmitter<boolean>();

  dialogDefault: Dialog = {
    title: '',
    content: 'Aguarde um momento...',
    close: false,
    disableClose:true,
    showSpinner:true,
    actions: undefined,
    callback: () =>{}
  }

  dialog(d:Dialog): void{
    this.dialoger.emit(d);
  }

  abrir():void{
    this.dialoger.emit(this.dialogDefault);
  }

  close():void{
    this.dialogerClose.emit(true);
  }
  fechar():void{
    this.close();
  }

  show(msg:string='',titulo:string='',showSpinner:boolean = true
        ,closeButton:boolean=true,fnt_callback={},disableCloseButton:boolean=false, actions:any = undefined):void{
    let dl: Dialog = {
      title: titulo,
      content: msg,
      close: closeButton,
      disableClose:disableCloseButton,
      showSpinner:showSpinner,
      callback: fnt_callback
      ,actions:actions
    }    
    this.dialoger.emit(dl);
  }

}
