import { throwMatDuplicatedDrawerError } from "@angular/material/sidenav";

//classe que contém funções uteis para aplicação
export class Funcoes{

  trataErro(arr:any,enclousure="li",cls=''):{}{
    //retorna um Html tratado com as mensagens de erro

    let cod:number=0;
    let id:number=0;
    let msg:string='';

    if(typeof arr=='string' && arr){
      return {cod:0,id:0,msg:arr};
    }else if(!arr){
      return {cod:0,id:0,msg:''};
    }

    cod = arr.cod?arr.cod:0;
    if(arr.msg){
      arr.errors
      msg=this.addEnclousure(arr.msg,enclousure,cls);
    }
    else{

      id = arr.id?arr.id:0;
    }

    //é um array
    let arr_errors= [];
    if(arr.errors){
      if(typeof arr.errors=='string'){



        if(enclousure && enclousure.toLowerCase()!='br'){
            msg+=`<${enclousure} ${cls}>`;
        }
        msg+=this.addEnclousure(arr.errors,enclousure,cls);

      }else{
        arr_errors = arr.errors;
        for(let j in arr_errors){
          msg+=this.addEnclousure(arr_errors[j],enclousure,cls);
         }
      }

    }


    return {cod:cod,id:id,msg:msg};
  }


  addEnclousure(val:string,enclousure:string='br',cls:string=''):string{
    let msg:string = '';

    val = this.mensagemTraduzida(val);

    if(enclousure && enclousure.toLowerCase()!='br'){
        msg+=`<${enclousure} class="${cls}">`;
    }

    msg+=val;
    if(enclousure){
        msg+=`<`
        if(enclousure.toLowerCase()!='br'){
            msg+='/';
        }
        msg+=`${enclousure}>`;
    }
    return msg;
  }


  mensagemTraduzida(str:string):string{
    let res = '';
    if(!str){
      return str;
    }
    res = str;

    if(str.indexOf('SQLSTATE[23000]')!=-1){
      res = 'O registro que está tentando inserir já existe no '+
      'banco de dados. Verifique os campos preenchidos, se necessário, altere as informações, e tente novamente.';
    }else if(str=='The comprovante cpf file failed to upload'){
      res = 'Não foi possível fazer upload do comprovante de cpf';
  }else if(str.indexOf('No query results for model')!=-1){
      res = 'Não foi possível encontrar encontrar o Objeto alvo. Geralmente isso acontece quando se tenta atualizar ou deletar um registro, e o elemento não existe.';
    }
    return res;
  }


  getRetornoTratado(res:any,msgComplemento:string='',callBackSuccess:any={},
    enclousure='li',cls='liErro',checaId=true):any{
    let arr_res:any =this.trataErro(res,enclousure,cls);
    let cod = arr_res.cod?arr_res.cod:0;
    let id = 0;
    if(!checaId){
      id = 1;
    }else{
      id = arr_res.id?arr_res.id:0;
    }

    let msg = arr_res.msg?arr_res.msg:'';
    let msgRetorno = msg;
    let tit = '';
    let txt = '';

    let callback_0 = undefined;
    if(cod<=0 || id<=0){
      tit='Erro ao tentar efetuar a operação';
      msg ='<h4><i class="fas fa-thumbs-up text-danger"></i>&nbsp;Não foi possível efetuar a operação. Verifique o preenchimento dos campos.</h4>'+
      (msg!=''?'<ul>'+msg+'</ul>':'');
      callBackSuccess = undefined; //não executa a função pois não deu certo
    }else{
      tit='Operação efetuada com sucesso!';
      msg ='<h4 class="tituloSucesso"><i class="fas fa-thumbs-up text-success"></i>&nbsp;'+
      'Tudo certo! Operação realizada com sucesso.</h4>'+
      (msgComplemento?'<p>'+msgComplemento+'</p>':'')+
      '<br>';
    }

    let dlg = {
      title:tit,
      content:msg,
      close: true,
      callback: callBackSuccess
    }

    return [cod,id,dlg,tit,msg,msgRetorno];

  }

  toFormData( formValue: any):any {
    const formData = new FormData();

    for ( const key of Object.keys(formValue) ) {

      let value = formValue[key];
      console.log(key,value,typeof value);
      if(value==null || typeof value=='undefined' || !value || value=='null'){
        continue;
      }
      formData.append(`${key}`, value);

    }

    return formData;
  }

  number_format (number:number, decimals:number = 0, dec_point:string=',', thousands_sep:string = '.'):string {
    let n = number, prec = decimals;

    let toFixedFix = function (n:number,prec:number):number {
        let k = Math.pow(10,prec);
        return (Math.round(n*k)/k);
    };

    n = !isFinite(+n) ? 0 : +n;
    prec = !isFinite(+prec) ? 0 : Math.abs(prec);    let sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep;
    let dec = (typeof dec_point === 'undefined') ? '.' : dec_point;

    let s = (prec > 0) ? toFixedFix(n, prec) : toFixedFix(Math.round(n), prec); //fix for IE parseFloat(0.55).toFixed(0) = 0;
    let abs = toFixedFix(Math.abs(n), prec);
    let _, i:number;
    let res:string = '';
    if (abs >= 1000) {
        _ = String(abs).split(/\D/);        i = _[0].length % 3 || 3;

        _[0] = String(s).slice(0,i + (n < 0?0:1)) + String(_[0]).slice(i).replace(/(\d{3})/g, sep+'$1');

        res = _.join(dec);    } else {
          res = res.replace('.', dec);
    }

    let decPos = res.indexOf(dec);    if (prec >= 1 && decPos !== -1 && (res.length-decPos-1) < prec) {
        res += new Array(prec-(res.length-decPos-1)).join('0')+'0';
    }
    else if (prec >= 1 && decPos === -1) {
      res += dec+new Array(prec).join('0')+'0';
    }
    return String(s);
  }

  number_format2(number:string, decimals:number = 0, dec_point:string = ',', thousands_sep:string = '.') {
    // Strip all characters but numerical ones.
    number = (number + '').replace(/[^0-9+\-Ee.]/g, '');
    let n = !isFinite(+number) ? 0 : +number;
    let prec = !isFinite(+decimals) ? 0 : Math.abs(decimals);
    let sep = typeof thousands_sep === 'undefined' ? ',' : thousands_sep;
    let dec = typeof dec_point === 'undefined' ? '.' : dec_point;
    let s: any = '';

    let toFixedFix = function (n:any, prec:any) {
      var k = Math.pow(10, prec);
      return '' + Math.round(n * k) / k;
    };
    // Fix for IE parseFloat(0.55).toFixed(0) = 0;
    s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
    if (s[0].length > 3) {
      s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
    }
    if ((s[1] || '').length < prec) {
      s[1] = s[1] || '';
      s[1] += new Array(prec - s[1].length + 1).join('0');
    }
    return s.join(dec);
  }


}

