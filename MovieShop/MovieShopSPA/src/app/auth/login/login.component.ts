import { Login } from './../../shared/models/login';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //two way binding
  //one way binding
  //object here

  userLogin: Login = {
    email: '',
    password: '',
  }

  constructor() { }

  ngOnInit(): void {
  }

  login(){
    console.log(this.userLogin);
  }

  get twoWayBindingInfo(){
    return JSON.stringify(this.userLogin);
  }
}
