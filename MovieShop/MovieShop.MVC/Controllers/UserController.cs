using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShop.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentUserService;

        private readonly IUserService _userService;

        public UserController(ICurrentUserService currentUserService, IUserService userService)
        {
            _currentUserService = currentUserService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            var id = (int)_currentUserService.UserId;
            var movies = await _userService.GetAllPurchasedMovie(id);
            return View(movies);
        }

        //[ServiceFilter(typeof(MovieShopHeaderFilterAttribute))]
        //public async Task<IActionResult> Purchases(PurchaseRequestModel purchaseRequestModel)
        //{
        //    //call user service with id and get list of movies that user purchased
        //    //it should look for cookie is present, cookie should not be expired and get the user id from cookie
        //   // await _userService.PurchaseMovie(purchaseRequestModel);
        //    return View();
        //}
    }
}
