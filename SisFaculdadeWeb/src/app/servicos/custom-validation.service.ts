import { Injectable } from '@angular/core';
import {ValidatorFn, AbstractControl, FormGroup, FormControl, ValidationErrors} from '@angular/forms';

@Injectable({
  providedIn: 'root'
})

export class CustomValidationService {

  //valida se a data é válida
  data(): ValidatorFn{
    return (control: AbstractControl): { [key: string]: any }|null => {
      if (!control.value) {
        return {dataInvalida:true};
      }

      let valido = null;
      let data = control.value;
      if(typeof data=='object'){
        if(typeof data._i=='object'){
          //pega o mês o dia e o ano
          data = data._i['date']+'/'+(data._i['month']+1)+'/'+data._i['year'];
        }else{
          data = data._i;
        }


      }







      let re = new RegExp(/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/)


      if (!re.test(data)) {
        valido = false;
      }else{
        valido = true;
      }

      //valida se é menor ou igual a hoje

      if(valido){
        return null;
      }else{
        return {dataInvalida:true}
      }
    };
  }



  //formata de forma generica os campos
formataCampo(campo:string, Mascara:string):string {
  var boleanoMascara;
  if(!campo){
    return '';
  }


  let exp = /\-|\.|\/|\(|\)| /g
  let campoSoNumeros = campo.toString().replace( exp, "" );

  let posicaoCampo = 0;
  let NovoValorCampo="";
  let TamanhoMascara = campoSoNumeros.length;;


  for(let i=0; i<= TamanhoMascara; i++) {
      boleanoMascara  = ((Mascara.charAt(i) == "-") || (Mascara.charAt(i) == ".")
                          || (Mascara.charAt(i) == "/"))
      boleanoMascara  = boleanoMascara || ((Mascara.charAt(i) == "(")
                          || (Mascara.charAt(i) == ")") || (Mascara.charAt(i) == " "))
      if (boleanoMascara) {
          NovoValorCampo += Mascara.charAt(i);
            TamanhoMascara++;
      }else {
          NovoValorCampo += campoSoNumeros.charAt(posicaoCampo);
          posicaoCampo++;
        }
    }

    return NovoValorCampo;

}

//madiciona mascara de data
mascaraData(data:string,onlyMask=false):string{
  let mask = '##/##/####';
  if(onlyMask==true){
    return mask;
  }
  return this.formataCampo(data, mask);
}

//madiciona mascara de data formato mysql
mascaraDataSQL(data:string,onlyMask=false):string{
  let mask = '0000-00-00';
  if(onlyMask==true){
    return mask;
  }
  return this.formataCampo(data, mask);
}



  constructor() { }
}
