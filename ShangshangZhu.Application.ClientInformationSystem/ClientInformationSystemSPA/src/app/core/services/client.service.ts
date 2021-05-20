import { Client } from './../../shared/models/Client';
import { AddClient } from './../../shared/models/AddClient';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private client!: AddClient;
  constructor(private apiService: ApiService) { }

  getAllClients(): Observable<Client[]>{
    return this.apiService.getList('clients/all')
  }

  getClientDetail(id: number){
    return this.apiService.getOne(`${'clients/'}`, id);
  }

  create(client: AddClient){
    return this.apiService.create('clients/add', client);
  }

  delete(id: number){
    return this.apiService.delete(`${'clients'}`, id)
  }

  update(client: AddClient){
    return this.apiService.update(`${'clients/update'}`, client)
  }
}
