using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MovieShop.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public AccountController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel userRegisterRequestModel)
        {
            var newUser = await _userService.RegisterUser(userRegisterRequestModel);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel userLoginRequestModel)
        {
            var user = await _userService.ValidateUser(userLoginRequestModel.Email, userLoginRequestModel.Password);
            if (user == null)
            {
                // Invalid User Name/Password                
                return View();
            }
            //if valid
            //cookie based authentication
            //claims, fName, lName, DOB
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.FirstName)
            };
            // Identity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // create cookie

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        [ServiceFilter(typeof(MovieShopHeaderFilterAttribute))]
        public async Task<IActionResult> Profile(int id)
        {
            var user = await _userService.GetUserProfile(id);
            return View(user);
        }
        [HttpGet]
        [ServiceFilter(typeof(MovieShopHeaderFilterAttribute))]
        public async Task<IActionResult> EditProfile()
        {
            //call DB and get user info and fill textbook 
            //so user can edit and see
            var id = (int)_currentUserService.UserId;
            var user = await _userService.GetUserProfile(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserProfileRequestModel userRequestModel)
        {
            // call user service and map the UserRequestModel data into User entity and call repository
            userRequestModel.Id = (int)_currentUserService.UserId;
            userRequestModel.Email = _currentUserService.Email;

            var newUser = await _userService.Edit(userRequestModel);
            return View(newUser);
        }
    }
}
