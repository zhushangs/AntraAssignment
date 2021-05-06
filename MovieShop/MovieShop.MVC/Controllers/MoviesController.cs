using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            return View(movie);
        }
        //public async Task<IActionResult> GetMoviesByGenre(int id)
        //{
        //    return View("~/Views/Home/Index.cshtml", movies);
        //    return View("~/Views/Home/Index.cshtml");
        //}

    }
}
