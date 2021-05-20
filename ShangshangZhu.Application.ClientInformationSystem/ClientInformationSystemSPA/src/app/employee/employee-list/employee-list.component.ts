import { Employee } from './../../shared/models/Employee';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from './../../core/services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  
  employees: Employee[] | undefined;

  constructor(private employeeService : EmployeeService, private router: ActivatedRoute) { }
 

  ngOnInit(): void {
    this.employeeService.getAllEmployees()
    .subscribe(
        e => {
          this.employees = e;
        }
    )
  }
}
