import { AuthService } from './../../core/services/auth.service';
import { Employee } from './../../shared/models/Employee';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from './../../core/services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  
  employees: Employee[] | undefined; 
  isAuth: boolean | undefined;

  //constructor(private employeeService : EmployeeService, private router: ActivatedRoute) { }
  constructor(private employeeService: EmployeeService, private route: ActivatedRoute, private router: Router, private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.isAuth.subscribe(isAuth => {
      this.isAuth = isAuth;
    });
    if(this.isAuth){
      this.employeeService.getAllEmployees()
      .subscribe(
          e => {
            this.employees = e;
          }
      )
    }
  }
}
