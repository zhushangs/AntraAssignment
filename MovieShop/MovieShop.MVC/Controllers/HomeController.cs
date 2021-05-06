using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShop.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using Infrastructure.Services;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;

namespace MovieShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private MovieShopDbContext _dbContext;
        public HomeController(IMovieService movieService, MovieShopDbContext movieShopDbContext)
        {
            _movieService = movieService;
            _dbContext = movieShopDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetTop30RevenueMovie();
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TopRatedMovies()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]                                                                                                                                                                                                                        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
