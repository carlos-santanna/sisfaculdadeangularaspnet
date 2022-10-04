import { NgModule } from '@angular/core';
import { DialogService } from 'src/app/servicos/dialog.service';
import { SidenavService } from 'src/app/servicos/sidenav.service';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LayoutModule } from '@angular/cdk/layout';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatToolbarModule } from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule } from '@angular/material/button';
import {MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import {AvatarModule } from "primeng/avatar";
import {TableModule} from 'primeng/table';
import { MatMenuModule } from '@angular/material/menu';
import {MatDividerModule} from '@angular/material/divider';
import { LocalStorageService } from 'src/app/servicos/local-storage.service';
import { PanelMenuModule } from 'primeng/panelmenu';
import { SnackbarComponent } from 'src/app/componentes/shared/snackbar/snackbar.component';
import { DialogComponent, DialogContentAppDialog } from 'src/app/componentes/shared/dialog/dialog.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { NotificationService } from 'src/app/servicos/notification.service';
import { MatSelectModule} from '@angular/material/select';
import {DialogModule} from 'primeng/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';
//pipes
import { DataDBPipe, DataPipe } from 'src/app/pipes/data.pipe';
import { DataComponent } from './data/data.component';
import { CustomValidationService } from 'src/app/servicos/custom-validation.service';

@NgModule({
  declarations: [
    SnackbarComponent, DialogComponent, DialogContentAppDialog
    ,DataPipe,DataDBPipe, DataComponent
  ],
  imports: [
    LayoutModule
    ,CommonModule
    ,ReactiveFormsModule 
    ,FlexLayoutModule
    ,MatToolbarModule
    ,MatCardModule
    ,MatButtonModule
    ,MatIconModule
    ,MatSidenavModule
    ,MatFormFieldModule
    ,MatInputModule
    ,MatSnackBarModule
    ,MatDatepickerModule
    ,AvatarModule
    ,TableModule
    ,PanelMenuModule
    ,MatMenuModule
    ,MatDividerModule
    ,MatDialogModule
    ,MatProgressSpinnerModule
    ,MatSelectModule
    ,DialogModule

  ]
  ,exports: [
    DataPipe
    ,DataDBPipe
    ,LayoutModule
    ,CommonModule
    ,ReactiveFormsModule
    ,FlexLayoutModule
    ,HttpClientModule
    ,LayoutModule
    ,MatToolbarModule
    ,MatCardModule
    ,MatButtonModule
    ,MatIconModule
    ,MatSidenavModule
    ,MatFormFieldModule
    ,MatInputModule
    ,MatSnackBarModule
    ,MatDatepickerModule
    ,AvatarModule
    ,TableModule
    ,PanelMenuModule
    ,MatMenuModule
    ,MatDividerModule
    ,MatDialogModule
    ,MatProgressSpinnerModule
    ,MatSelectModule
    ,DialogComponent
    ,SnackbarComponent
    ,DialogModule
    ,DialogComponent, DialogContentAppDialog
    ,DataComponent

  ],
  providers: [
    DialogService, SidenavService, LocalStorageService, NotificationService,DataPipe,DataDBPipe, CustomValidationService
  ]
  
  
})
export class SharedModule { }
