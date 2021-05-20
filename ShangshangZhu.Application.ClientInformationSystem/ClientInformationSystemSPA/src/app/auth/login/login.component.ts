import { Router } from '@angular/router';
import { AuthService } from './../../core/services/auth.service';
import { Login } from './../../shared/models/login';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLogin: Login = {
    name: '',
    password: '',
  }
  invalidLogin: boolean | undefined;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    console.log(` buttun was clicked`);
    // call login method in auth service
    this.authService.login(this.userLogin).subscribe(
      (response) => {
        if (response) {
          // if auth service returns true redirect to home page
          this.router.navigate(['/']);
          // 2XX
        } else {
          // stay on the same page and show some error message saying un/pw is invalid
          this.invalidLogin = true;
        }
      },
      (err: any) => {
        (this.invalidLogin = true), console.log(err);
      }
    );
  }

}
