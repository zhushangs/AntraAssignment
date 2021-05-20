import { AddInteraction } from './../../shared/models/AddInteraction';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Interaction } from './../../shared/models/Interaction';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InteractionService {

  private interation!: AddInteraction
  constructor(private apiService: ApiService) { }

  getAllInteractions(): Observable<Interaction[]>{
    return this.apiService.getList('interactions/all')
  }

  getInteractionDetail(id: number){
    return this.apiService.getOne(`${'interactions/'}`, id);
  }

  create(interation: AddInteraction){
    return this.apiService.create('interactions/add', interation);
  }

  delete(id: number){
    return this.apiService.delete(`${'interactions'}`, id)
  }

  update(interation: AddInteraction){
    return this.apiService.update(`${'interactions/update'}`, interation)
  }
}
