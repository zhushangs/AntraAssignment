import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
@Injectable({
  providedIn: 'root'
})
export class MovieService {

  // talk with movie api
  constructor(private apiService : ApiService) { }

  getMovieDetails(id:number){
    this.apiService.getOne(`${'movies/'}`, id);
  }
}
