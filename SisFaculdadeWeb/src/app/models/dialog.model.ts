export interface Dialog{
  title?: string;
  content?: string;
  actions?: any;
  close?: boolean|object;
  disableClose?:boolean;
  showSpinner?:boolean;
  callback?:any;
}
