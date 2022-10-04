import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  notifier = new EventEmitter<string>()

  notify(mensagem: string): void{
    this.notifier.emit(mensagem);
  }

}
