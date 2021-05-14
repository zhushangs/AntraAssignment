import { MovieService } from './../../../core/services/movie.service';
import { Component, Input, OnInit } from '@angular/core';
import { MovieCard } from '../../models/movieCard';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {

  @Input() movie: MovieCard | undefined;
  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
  }

}
