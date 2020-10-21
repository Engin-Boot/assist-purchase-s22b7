import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminService } from '../services/AdminService';
import { ProductsComponent } from './products/products.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { DialogBoxComponent } from './dialog-box/dialog-box.component';
import { LoginComponent } from './login/login.component';



@NgModule({
  declarations: [ProductsComponent, DialogBoxComponent, LoginComponent],
  imports: [
    CommonModule,
    AdminService,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    MatTableModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatInputModule
  ]
})
export class AdminModule { }
