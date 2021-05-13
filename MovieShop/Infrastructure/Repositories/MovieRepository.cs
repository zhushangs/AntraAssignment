using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetTop30HighestRevenueMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }
        public async Task<IEnumerable<Movie>> GetTop30HighestRatedMovies()
        {
            var movies = await _dbContext.Reviews.Include(r => r.Movie)
                        .GroupBy(r => new { r.Movie.Id, r.Movie.PosterUrl, r.Movie.Title })
                        .OrderByDescending(g => g.Average(r => r.Rating))
                        .Select(m => new Movie
                        {
                            Id = m.Key.Id,
                            PosterUrl = m.Key.PosterUrl,
                            Title = m.Key.Title,
                            Rating = m.Average(r => r.Rating)
                        }).Take(30).ToListAsync();

            return movies;

        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.AsNoTracking().Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);
           
            var rating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
                .AverageAsync(r => r == null ? 0 : r.Rating);
            if (rating > 0) movie.Rating = rating;

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int id)
        {
            var movies = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Id == id)
                .SelectMany(g => g.Movies).ToListAsync(); 
            //return movies;
            return movies;
        }

        public async Task<IEnumerable<Review>> GetMoviesReviewsAsync(int id)
        {
            var reviews = await _dbContext.Reviews.Where(r=>r.MovieId == id).Include(r => r.Movie).ToListAsync();
            return reviews;
        }
    }
}
