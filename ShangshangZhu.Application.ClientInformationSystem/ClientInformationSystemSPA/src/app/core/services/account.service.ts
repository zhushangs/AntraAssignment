import { Register } from './../../shared/models/Register';
import { Employee } from './../../shared/models/Employee';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private user!: Register;
  constructor(private apiService: ApiService) {}

  register(user: Register) {
      return this.apiService.create('account', user);
  }
}
