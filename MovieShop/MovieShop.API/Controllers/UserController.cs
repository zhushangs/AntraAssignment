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
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<ActionResult> GetUserPurchasedMoviesAsync(int id)
        {
            var userMovies = await _userService.GetAllPurchasedMovie(id);
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
            var isFavorite = await _userService.IsFavoriteMovie(id, movieId);
            return Ok(isFavorite);
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<ActionResult> PurchaseMovie(PurchaseRequestModel purchaseRequestModel)
        {
            var purchase = await _userService.PurchaseMovie(purchaseRequestModel);
            return Ok(purchase);
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
        public async Task<ActionResult> DeleteMovieReview(int userId, int movieId)
        {
            await _userService.DeleteMovieReview(userId, movieId);
            return NoContent();
        }
    }
}
