using ApplicationCore.Entities;
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

        public async Task<MovieCardResponseModel> GetMovieById(int id)
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
    }
}
