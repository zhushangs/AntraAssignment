using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetUserPurchase()
        {
            //call user service with id and get list of movies that user purchased
            //it should look for cookie is present, cookie should not be expired and get the user id from cookie
            return View();
        }
    }
}
