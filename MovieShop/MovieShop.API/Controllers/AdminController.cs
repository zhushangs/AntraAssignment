using ApplicationCore.Models.Request;
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
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        public AdminController(IMovieService movieService, IUserService userService)
        {
            _movieService = movieService;
            _userService = userService;
        }

        [HttpGet]
        [Route("movie")]
        public async Task<IActionResult> GetPurchase()
        {
            var movies = await _movieService.GetAllMoviePurchases();
            return Ok(movies);
            //return Ok();
        }

        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> AddMovie(MovieCreateRequestModel movieCreateRequestModel)
        {
            var createdMovie = await _movieService.CreateMovie(movieCreateRequestModel);
            return CreatedAtRoute("GetMovie", new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> UpdateMovie(MovieUpdatedRequestModel movieUpdatedRequestModel)
        {
            var updatedMovies = await _movieService.UpdateMovie(movieUpdatedRequestModel);
            return CreatedAtRoute("GetMovie", new { id = updatedMovies.Id }, updatedMovies);
        }
    }
}
