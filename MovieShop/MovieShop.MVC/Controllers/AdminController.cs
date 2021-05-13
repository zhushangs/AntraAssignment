using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        public AdminController(IMovieService movieService, IUserService userService)
        {
            _movieService = movieService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync(MovieCreateRequestModel movieCreateRequestModel)
        {
            //take info from view and save it to DB
            var createdMovie = await _movieService.CreateMovie(movieCreateRequestModel);
            return View();
        }

        [HttpGet]
        public IActionResult CreateMovie()
        {
            //show empty page so admin can enter info
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovieAsync(MovieUpdatedRequestModel movieUpdatedRequestModel)
        {
            //take info from view and save it to DB
            var updatedMovies = await _movieService.UpdateMovie(movieUpdatedRequestModel);
            return View();
        }

        [HttpGet]
        public IActionResult UpdateMovie()
        {
            //show empty page so admin can enter info
            return View();
        }
    }
}
