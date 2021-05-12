using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Models.Response.MovieCardResponseModel;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICastRepository _castRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieService(IMovieRepository movieRepository, ICastRepository castRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _castRepository = castRepository;
            _genreRepository = genreRepository;
        }

        public async Task<MovieCardResponseModel> CreateMovie(MovieCreateRequestModel movieCreateRequestModel)
        {
            var movie = new Movie
            {
                Title = movieCreateRequestModel.Title,
                Budget = movieCreateRequestModel.Budget,
                Revenue = movieCreateRequestModel.Revenue,
            };
            var response = await _movieRepository.AddAsync(movie);
            var createdMovie = new MovieCardResponseModel
            {
                Id = response.Id,
                Title = response.Title,
                Budget = response.Budget,
                Revenue = response.Revenue,
            };
            return createdMovie;
        }

        public async Task<MovieCardResponseModel> UpdateMovie(MovieUpdateRequestModel movieUpdateRequestModel)
        {
            var dbMovie = await _movieRepository.GetByIdAsync(movieUpdateRequestModel.Id);
            if (dbMovie == null)
            {
                throw new NotFoundException("Movie Not exists");
            }
            var movie = new Movie
            {
                Id = movieUpdateRequestModel.Id,
                Title = movieUpdateRequestModel.Title == null? dbMovie.Title: movieUpdateRequestModel.Title,
                Budget = movieUpdateRequestModel.Budget == 0 ? dbMovie.Budget : movieUpdateRequestModel.Budget,
                Revenue = movieUpdateRequestModel.Revenue == 0 ? dbMovie.Revenue : movieUpdateRequestModel.Revenue,
            };
            var response = await _movieRepository.UpdateAsync(movie);
            var updatedMovie = new MovieCardResponseModel
            {
                Id = response.Id,
                Budget = response.Budget,
                Title = response.Title,
                Revenue = response.Revenue,
            };
            return updatedMovie;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetAllMovies()
        {
            var movies = await _movieRepository.ListAllAsync();
            var allMovies = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                allMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return allMovies;
        }

        public async Task<List<MovieCardResponseModel>> GetTop30RevenueMovie()
        {
            var movies = await _movieRepository.GetTop30HighestRevenueMovies();
            var topMovies = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                topMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return topMovies;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetTop30RatedMovie()
        {
            var movies = await _movieRepository.GetTop30HighestRevenueMovies();
            var response = movies.Select(m => new MovieCardResponseModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            });
            return response;
        }

        public async Task<MovieCardResponseModel> GetMovieCardById(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            var genreList = new List<GenreResponseModel>();
            foreach (var genre in movie.Genres)
            {
                var theGenre = await _genreRepository.GetByIdAsync(genre.Id);
                genreList.Add(new GenreResponseModel
                {
                    Id = theGenre.Id,
                    Name = theGenre.Name,
                });
            }
            var castList = new List<CastDetailResponseModel>();
            foreach (var cast in movie.MovieCasts)
            {
                var theCast = await _castRepository.GetByIdAsync(cast.CastId);
                castList.Add(new CastDetailResponseModel
                {
                    Id = theCast.Id,
                    Name = theCast.Name,
                    ProfilePath = theCast.ProfilePath,
                    Character = cast.Character,
                });
            }
            var theMovie = new MovieCardResponseModel
            {
                Id = movie.Id,
                Budget = movie.Budget,
                Title = movie.Title,
                BackdropUrl = movie.BackdropUrl,
                PosterUrl = movie.PosterUrl,
                Tagline = movie.Tagline,
                RunTime = movie.RunTime,
                Overview = movie.Overview,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate,
                Rating = movie.Rating,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                Genres = genreList,
                Casts = castList,
            };
            return theMovie;
        }

        public async Task<List<MovieCardResponseModel>> GetMoviesByGenre(int id)
        {
            var movies = await _movieRepository.GetMoviesByGenreAsync(id);
            var moviesByGenre = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                moviesByGenre.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return moviesByGenre;
        }

        public async Task<IEnumerable<MovieReviewResponseModel>> GetMovieReviews(int id)
        {
            var reviews = await _movieRepository.GetMoviesReviewsAsync(id);
            var response = reviews.Select(m => new MovieReviewResponseModel
            {
                UserId = m.UserId,
                MovieId = m.MovieId,
                Rating = m.Rating,
                ReviewText = m.ReviewText,
            });
            return (IEnumerable<MovieReviewResponseModel>)response;
        }
    }
}