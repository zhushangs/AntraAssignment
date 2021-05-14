import { Genre } from './genre';
import { Cast } from './cast';

export interface MovieCard {
    // id: number;
    // title: string;
    // budget: number;
    // posterUrl: string;

  id: number;
  title: string;
  posterUrl: string;
  tagline: string;
  runTime: number;
  createdDate: Date;
  price: number;
  rating: number;
  overview: string;
  budget: number;
  revenue: number;
  releaseDate: Date;
  imdbUrl: string;
  backdropUrl: string;

  isFavoriteByUser: boolean;
  isPurchasedByUser: boolean;

  genres: Genre[];
  casts: Cast[];
}
