import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { MovieCard } from '../shared/models/movieCard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  movies: MovieCard[] | undefined;

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {

    this.movieService.getTopRevenueMovies().subscribe(
      m => {
        this.movies = m;
        //console.table(this.movies);
      }
    );

  }

}
