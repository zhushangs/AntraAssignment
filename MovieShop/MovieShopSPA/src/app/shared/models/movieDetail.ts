export interface Genre {
    id: number;
    name: string;
}

export interface Cast {
    id: number;
    name: string;
    gender?: any;
    tmdbUrl?: any;
    profilePath: string;
    character: string;
}

export interface MovieDetail {
    id: number;
    title: string;
    posterUrl: string;
    backdropUrl: string;
    rating: number;
    overview: string;
    tagline: string;
    budget: number;
    revenue: number;
    imdbUrl: string;
    tmdbUrl?: any;
    releaseDate: Date;
    runTime: number;
    price: number;
    favoritesCount: number;
    genres: Genre[];
    casts: Cast[];
}
