import { AddEmployee } from './../../shared/models/AddEmployee';
import { Employee } from './../../shared/models/Employee';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employee!: AddEmployee;
  constructor(private apiService: ApiService) { }

  getEmployeeProfile(id: number){
    return this.apiService.getOne(`${'employees/'}`, id);
  }

  getAllEmployees(): Observable<Employee[]>{
    return this.apiService.getList('employees/all');
  }

  delete(id: number){
    return this.apiService.delete(`${'employees'}`, id)
  }

  update(employee: AddEmployee){
    return this.apiService.update(`${'employees/update'}`, employee)
  }
}
