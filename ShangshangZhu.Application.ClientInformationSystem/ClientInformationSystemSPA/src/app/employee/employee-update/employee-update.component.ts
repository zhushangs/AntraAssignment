import { EmployeeService } from './../../core/services/employee.service';
import { AddEmployee } from './../../shared/models/AddEmployee';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-employee-update',
  templateUrl: './employee-update.component.html',
  styleUrls: ['./employee-update.component.css']
})
export class EmployeeUpdateComponent implements OnInit {

  employee: AddEmployee = {
      name: '',
      password: '',
      designation: '',
  }
  constructor(private employeeService: EmployeeService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
      this.route.params.subscribe(params => {
      if(params['id']){
        this.employeeService.getEmployeeProfile(params['id']).subscribe((employee) => {
          this.employee = employee;
        });
      }
    });
  }
  update(){
    this.employeeService.update(this.employee).subscribe(
          (response) => {
            if (response) {
              this.router.navigate(['/employees']);
            }else{
              console.log("error");
            }
          },
    );
  }
}
