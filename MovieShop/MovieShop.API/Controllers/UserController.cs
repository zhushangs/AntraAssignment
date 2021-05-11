using ApplicationCore.Models.Request;
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

        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<ActionResult> GetUserPurchasedMoviesAsync(int id)
        {
            var userMovies = await _purchaseService.GetAllPurchasedMovie(id);
            return Ok(userMovies);
        }
        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<ActionResult> GetUserReviewsById(int id)
        {
            var reviews = await _userService.GetUserReviews(id);
            return Ok(reviews);
        }
        [HttpGet]
        [Route("{id:int}/favorites")]
        public async Task<ActionResult> GetUserFavoritesById(int id)
        {
            var favorites = await _userService.GetUserFavoriteMovies(id);
            return Ok(favorites);
        }

        [HttpGet]
        [Route("{id:int}/movie/{movieId}/favorite")]
        public async Task<ActionResult> GetUserFavoriteById(int id, int movieId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<ActionResult> PurchaseMovie(PurchaseRequestModel purchaseRequestModel)
        {
            var purchase = _userService.PurchaseMovie(purchaseRequestModel);
            return Ok();
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<ActionResult> AddFavoriteMovies()
        {
            //await _userService.AddFavorite();
            return Ok();
        }

        [HttpPost]
        [Route("unfavorite")]
        public async Task<ActionResult> RemoveFavoriteMovies()
        {
            return Ok();
        }

        [HttpPost]
        [Route("review")]
        public async Task<ActionResult> AddReview()
        {
            return Ok();
        }

        [HttpPut]
        [Route("review")]
        public async Task<ActionResult> EditReview()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{userId:int}/movie/{movieId}")]
        public async Task<ActionResult> DeleteMovie()
        {
            return Ok();
        }
    }
}
