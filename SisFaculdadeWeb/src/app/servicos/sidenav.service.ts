import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SidenavService {
  messageSideNav: BehaviorSubject<string> = new BehaviorSubject('')
  messageSideNavStatus: BehaviorSubject<string> = new BehaviorSubject('')
  constructor() { }

  toggle(){
    this.messageSideNav.next('toggle');
  }

  hideOrShow(tp:string='show'){
    this.messageSideNav.next(tp);
  }

  statusSideNav(tp:any){
    this.messageSideNavStatus.next(tp);
  }
}
