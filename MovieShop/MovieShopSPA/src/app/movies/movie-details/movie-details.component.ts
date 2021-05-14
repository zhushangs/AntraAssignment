import { MovieCard } from 'src/app/shared/models/movieCard';
import { MovieDetail } from './../../shared/models/movieDetail';
import { Component, OnInit } from '@angular/core';
import { MovieService } from './../../core/services/movie.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  movie: MovieCard | undefined;
  constructor(private movieService: MovieService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.params.subscribe(params => {
      if(params['id']){
        this.movieService.getMovieDetails(params['id']).subscribe((movie) => {
          this.movie = movie;
        });
      }
    });
  }
}
