using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTop30RevenueMovie();
            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("No Movies Found");
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTop30RatedMovie();
            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("No Movies Found");
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenre(genreId);
            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("No Movies Found");
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetMovie")]
        public async Task<IActionResult> GetMoviesById(int id)
        {
            var movie = await _movieService.GetMovieCardById(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("No Movies Found");
        }

        [HttpGet]
        [Route("{id:int}/review")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var reivews = await _movieService.GetMovieReviews(id);
            if (reivews.Any())
            {
                return Ok(reivews);
            }
            return NotFound("No Reivews Found");
        }
    }
}
