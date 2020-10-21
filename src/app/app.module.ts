import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AdminService } from './services/admin.service';
import { DashboardService } from './services/dashboard.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  exports: [
    HttpClientModule
  ],
  providers: [
    {provide:'apiBaseAddress', useValue:"http://localhost:53010"}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
