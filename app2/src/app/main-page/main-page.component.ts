import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  constructor(private route:Router) { }
  ngOnInit() {
    
  }

  onLogin(){

    //Validate Credentials
    //Navigate -> MainDashBoard
    this.route.navigate(['login']);
  
   }
  
  
   onSearch(){
     this.route.navigate(['search']);
   }

}
