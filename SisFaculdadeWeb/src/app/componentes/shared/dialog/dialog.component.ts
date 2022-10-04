import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogModule, MAT_DIALOG_DATA, MatDialogConfig } from '@angular/material/dialog'
import { Dialog } from 'src/app/models/dialog.model';
import { DialogService } from 'src/app/servicos/dialog.service';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html'
})

export class DialogComponent implements OnInit {

  constructor(private ds:DialogService, public d: MatDialog) { }

  dialogContent?:Dialog = {
    title:'',
    content:'',
    actions:'',
    close: false,
    disableClose: true,
    showSpinner: true,
    callback: () =>{}
  }

  ngOnInit(): void {
    this.ds.dialoger.subscribe(
      {
        next: (res:Dialog)=>{
          this.openDialog(res);
        }
        ,
        error: (e:any)=>{
          console.log('erro',e.message)
        },
      }
    )

    this.ds.dialogerClose.subscribe(
      {
        next: ()=>{
          this.closeDialog()
        }
        ,
        error: (e:any)=>{
          console.log('erro ao tentar fechar',e.message)
        },
      }
    )
  }

  openDialog(ddL:Dialog):boolean{
    if(!ddL){
      return false;
    }

    this.dialogContent = ddL;
    const dialogRef = this.d.open(DialogContentAppDialog,{
      data: this.dialogContent
      ,disableClose: this.dialogContent.disableClose
    });

    if(this.dialogContent.callback){
      dialogRef.afterClosed().subscribe(this.dialogContent.callback);
    }





    return true;

  }

  closeDialog(){
    this.d.closeAll();
  }

}

@Component({
  selector: 'dialog-content-app-dialog',
  templateUrl: 'dialog-content.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogContentAppDialog {
  constructor(@Inject(MAT_DIALOG_DATA) public data: Dialog){    
  }
}
