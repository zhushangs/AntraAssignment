import { MovieService } from './../../core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/movieCard';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-card-list',
  templateUrl: './movie-card-list.component.html',
  styleUrls: ['./movie-card-list.component.css']
})
export class MovieCardListComponent implements OnInit {

  movies: MovieCard[] | undefined;

  constructor(private movieService: MovieService, private route: ActivatedRoute) { }

  ngOnInit(): void {


  this.route.params.subscribe(params => {
      if(params['id']){
        this.movieService.getMoviesByGenre(params['id']).subscribe((movies) => {
          this.movies = movies;
        });
      }
    });
  }

}
