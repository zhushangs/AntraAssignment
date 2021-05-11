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
        public AdminController(IUserService userService)
        {
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
        public async Task<IActionResult> AddMovie()
        {
            return Ok();
        }

        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> EditMovie()
        {
            return Ok();
        }
    }
}
