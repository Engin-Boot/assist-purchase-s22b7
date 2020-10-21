import { Component } from '@angular/core';
import {Router} from '@angular/router'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'App';
  
constructor(private route:Router) { }

onLogin(){

  //Validate Credentials
  //Navigate -> MainDashBoard
  this.route.navigate(['admin']);

 }


 onSearch(){
   this.route.navigate(['searchProduct']);
 }
}
