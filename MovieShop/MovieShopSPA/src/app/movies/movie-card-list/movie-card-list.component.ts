import { MovieService } from './../../core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/movieCard';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-movie-card-list',
  templateUrl: './movie-card-list.component.html',
  styleUrls: ['./movie-card-list.component.css']
})
export class MovieCardListComponent implements OnInit {

  movies: MovieCard[] | undefined;
  //genreId: number;
  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    // this.movieService.getMovieByGenre().subscribe(
    //   m => {
    //     this.movies = m;
    //     console.table(this.movies);
    //   }
    // );
  }

}
