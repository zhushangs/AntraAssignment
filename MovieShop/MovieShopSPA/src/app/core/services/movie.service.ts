import { MovieDetail } from './../../shared/models/movieDetail';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieCard } from 'src/app/shared/models/movieCard';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  // talk with Movie API
  constructor(private apiService: ApiService) { }

  //Called by Movie Details Component
  getMovieDetails(id: number) {
    return this.apiService.getOne(`${'movies/'}`, id);
  }

  getTopRevenueMovies(): Observable<MovieCard[]> {
    return this.apiService.getList('movies/toprevenue');
  }

  getMoviesByGenre(genreId: number): Observable<MovieCard[]> {
    return this.apiService.getList(`movies/genre/${genreId}`);
  }

}
