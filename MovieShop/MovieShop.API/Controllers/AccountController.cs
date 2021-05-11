using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register(UserRegisterRequestModel userRegisterRequestModel)
        {
            var user = await _userService.RegisterUser(userRegisterRequestModel);
            return CreatedAtRoute("GetUser", new { id = user.Id}, user);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpGet]
        //[Route("", Name ="GetAccount")]
        public async Task<IActionResult> GetUser(LoginResponseModel loginResponseModel)
        {
            //var claims = new List<Claim>()
            //{
            //    new Claim(ClaimTypes.Email, loginResponseModel.Email),
            //    new Claim(ClaimTypes.Surname, loginResponseModel.LastName),
            //    new Claim(ClaimTypes.NameIdentifier, loginResponseModel.Id.ToString()),
            //    new Claim(ClaimTypes.GivenName, loginResponseModel.FirstName)
            //};
            //// Identity
            //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //// create cookie

            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            //    new ClaimsPrincipal(claimsIdentity));
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginRequestModel userLoginRequestModel)
        {
            //var user = await _userService.ValidateUser(userLoginRequestModel.Email, userLoginRequestModel.Password);
            //if (user == null)
            //{           
            //    return NotFound("No User Found");
            //}
            //return CreatedAtRoute("GetAccount", new { token = GetUser(user) });

            return Ok();
        }
    }
}
