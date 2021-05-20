import { AccountService } from './../../core/services/account.service';
import { Register } from './../../shared/models/Register';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userRegister: Register = {
    name:'',
    password: '',
    designation: '',
  }
  invalidRegister: boolean | undefined;
  constructor(private router: Router, private accountService: AccountService) { }

  ngOnInit(): void {
    console.log(this.userRegister);
  }

  register(){
    this.accountService.register(this.userRegister).subscribe(
      (response) => {
        if (response) {
          this.router.navigate(['/login']);
        }else{
          this.invalidRegister = true;
        }
      },
      (err: any) => {
        (this.invalidRegister = true), console.log(err);
      }
    );
  }

}
