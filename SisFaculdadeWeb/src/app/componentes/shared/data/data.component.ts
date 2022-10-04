import { Component, OnInit,Inject, Input,ViewEncapsulation, forwardRef, OnChanges, SimpleChanges} from '@angular/core';
import { ControlContainer, FormControl, ControlValueAccessor, AbstractControl, NG_VALUE_ACCESSOR } from '@angular/forms';

import {
  MAT_MOMENT_DATE_FORMATS,
  MomentDateAdapter,
  MAT_MOMENT_DATE_ADAPTER_OPTIONS,
} from '@angular/material-moment-adapter';
import {DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE} from '@angular/material/core';
import 'moment/locale/pt-br';
import { CustomValidationService } from 'src/app/servicos/custom-validation.service';


export const MY_DATE_FORMATS = {
  parse: {
    dateInput: 'DD-MM-YYYY',
  },
  display: {
    dateInput: 'MMM DD, YYYY',
    monthYearLabel: 'MMMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY'
  },
};


@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.css']
  ,providers: [
    // The locale would typically be provided on the root module of your application. We do it at
    // the component level here, due to limitations of our example generation script.
    {provide: MAT_DATE_LOCALE, useValue: 'pt-br'},

    // `MomentDateAdapter` and `MAT_MOMENT_DATE_FORMATS` can be automatically provided by importing
    // `MatMomentDateModule` in your applications root module. We provide it at the component level
    // here, due to limitations of our example generation script.
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
    },
    {provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS},

    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DataComponent),
      multi: true
    }

  ],
})
export class DataComponent implements ControlValueAccessor,OnInit, OnChanges{
  @Input()
  formControlName:string = '';

  input?: AbstractControl | null;

  @Input()
  placeholder:string = '';

  @Input()
  type:string = 'text';


  @Input()
  label:string = '';

  @Input()
  name:string = '';


  @Input()
  errorMessage:string = '';


  @Input()
  startDate:string = '1900-01-01'; //currentYear, currentMonth, today, 25/12/2022 | 2022-12-25

  @Input() endDate:string = 'today'; //currentYear, currentMonth, today, 25/12/2022 | 2022-12-25

  qtd_years_if_not_limit = 5; //currentYear + qtd_years_if_No_limit

  //limita a data de 1900 até hoje
  currentYear = new Date().getFullYear();
  minDate?: Date;
  maxDate?: Date;


  @Input() mask:any


  data?:string;


  constructor( private _adapter: DateAdapter<any>,
    @Inject(MAT_DATE_LOCALE) private _locale: string, private controlContainer: ControlContainer
    ,public validacao:CustomValidationService

    ) {

      this.trataMinMaxDate();

    }
  trataMinMaxDate(){
    this.minDate = this.trataDataInicioFim(this.startDate); //1900-01-01
    if(this.endDate==''){
      this.maxDate = new Date(new Date().getFullYear() + this.qtd_years_if_not_limit, 11, 31);
    }else{
      console.log(this.endDate,'data')
      this.maxDate = this.trataDataInicioFim(this.endDate);
    }
  }
  ngOnChanges(changes: SimpleChanges): void {
    if(changes['endDate']){
      this.trataMinMaxDate()
    }
  }

  ngOnInit(): void {
     if(!this.formControlName){
      throw new Error('Forneça a propriedade formControlName para ser utilizado no compomente');
    }else{
      if(this.controlContainer && this.formControlName){
        if(this.controlContainer.control){
          this.input = this.controlContainer.control.get(this.formControlName);
        }

      }
    }
  }

  trataDataInicioFim(dt:string):Date{
    let data = new Date(0);
    if(!dt){
      return data;
    }
    dt = dt.toLowerCase().trim();
    if(dt=='today'){
      data = new Date();
    }else if(dt=='currentMonth'){
      data = new Date(new Date().getFullYear(),new Date().getMonth(),1);
    }else if(dt=='currentYear'){
      data = new Date(new Date().getFullYear(),11,31);
    }else{
      let mes=0;
      let dia=0;
      let ano=0;
      if(dt.indexOf('-')>-1){
        let arr = dt.split('-');
        mes=parseInt(arr[1])-1;
        dia=parseInt(arr[2]);
        ano=parseInt(arr[0]);
      }else if(dt.indexOf('/')>-1){
        let arr = dt.split('/');
        mes=parseInt(arr[1])-1;
        dia=parseInt(arr[2]);
        ano=parseInt(arr[0]);
      }
      data = new Date(ano,mes,dia);
    }
    return data
  }


  registerOnChange(){

  }

  registerOnTouched(){

  }
  writeValue(){

  }
  setDisabledState(){

  }

  isInvalid():boolean{
    let res = false;
    res = (this.input?.invalid && (this.input?.dirty || this.input?.touched)) ?true:false;
    return res
  }

  onBlur(dt:any){
    let dt0 = dt.replace(/[^0-9.]/g,"")
    let res = dt;
    if(dt0){
      if(dt0.length===8){
        res = this.validacao.mascaraData(dt0);

      }

    }
    return res;
  }

}
