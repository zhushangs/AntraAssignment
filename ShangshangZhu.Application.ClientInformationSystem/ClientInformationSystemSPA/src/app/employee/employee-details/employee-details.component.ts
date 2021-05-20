import { AuthService } from './../../core/services/auth.service';
import { Employee } from './../../shared/models/Employee';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from './../../core/services/employee.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {

  employee: Employee | undefined;
  isAuth: boolean | undefined;
  //constructor(private employeeService: EmployeeService, private route: ActivatedRoute, private router: Router) { }
  constructor(private employeeService: EmployeeService, private route: ActivatedRoute, private router: Router, private authService: AuthService) { }
  ngOnInit(): void {
    this.authService.isAuth.subscribe(isAuth => {
      this.isAuth = isAuth;
    });

    if(this.isAuth == true){
      this.route.params.subscribe(params => {
        if(params['id']){
          this.employeeService.getEmployeeProfile(params['id']).subscribe((employee) => {
            this.employee = employee;
          });
        }
      });
    }
  }

  delete(){
      this.route.params.subscribe(params => {
        if(params['id']){
          this.employeeService.delete(params['id']).subscribe(
            (response) => {
              if (response) {
                this.router.navigate(['/employees']);
              }
          });
        }
      });
    }
}
