using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private readonly IPurchaseService _purchaseService;
        public UserController(IUserService userService, IMovieService movieService, IPurchaseService purchaseService)
        {
            _userService = userService;
            _movieService = movieService;
            _purchaseService = purchaseService;
        }


        [HttpGet("{id:int}/purchases")]
        public async Task<ActionResult> GetUserPurchasedMoviesAsync(int id)
        {
            var userMovies = await _purchaseService.GetAllPurchasedMovie(id);
            return Ok(userMovies);
        }
    }
}
