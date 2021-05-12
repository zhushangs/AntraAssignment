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
            return Ok();
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
        public async Task<IActionResult> EditMovie(MovieUpdateRequestModel movieUpdateRequestModel)
        {
            var updatedMovie = await _movieService.UpdateMovie(movieUpdateRequestModel);
            return Ok(updatedMovie);
        }
    }
}
