using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(MovieCreateRequestModel movieCreateRequestModel)
        {
            //take info from view and save it to DB
            return View();
        }

        [HttpGet]
        public IActionResult CreateMovie()
        {
            //show empty page so admin can enter info
            return View();
        }
    }
}
