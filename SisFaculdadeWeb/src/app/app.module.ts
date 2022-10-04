import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './componentes/shared/shared.module';


@NgModule({
  declarations: [
    AppComponent     
  ],
  imports: [
    BrowserModule    
    ,FormsModule
    ,ReactiveFormsModule
    ,BrowserAnimationsModule
    ,HttpClientModule    
   ,SharedModule
   ,AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
  ,exports: [
    
  ]
})
export class AppModule { }
