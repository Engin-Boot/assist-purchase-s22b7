import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userName:string=""
  password:string=""
  errorMessage:string=""
  constructor(private route:Router) { }

  ngOnInit(): void {
  }

  onLogin(){

    //if(this.userName=="admin" && this.password=="admin@123"){
    //  this.errorMessage="Login Successfull";
      this.route.navigate(['admin/products']);
    //}
    //else{
    //  this.errorMessage="Invald Credentials";
    //}

  }
  onReset(){

    this.userName="";
    this.password="";
    this.errorMessage="";
  }
}
