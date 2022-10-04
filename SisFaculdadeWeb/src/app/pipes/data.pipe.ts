import { Pipe, PipeTransform } from "@angular/core";

@Pipe({"name": "data"})

export class DataPipe implements PipeTransform{
  transform(value:string):string{
    
    let valorFormatado = '';
    if(value){
      if(value.indexOf("T")>-1){
        value = value.split("T")[0];
      }
      let arr:any[] = value.split('-');
      valorFormatado = arr[2]+'/'+arr[1]+'/'+arr[0];
    }
    return valorFormatado;
  }
}

@Pipe({"name": "dataDB"})
export class DataDBPipe implements PipeTransform{
  transform(value:string):string{
    
    let valorFormatado = '';
    if(value){
      if(value.indexOf("T")>-1){
        value = value.split("T")[0];
      }      
      valorFormatado = value[0];
    }
    return valorFormatado;
  }
}
