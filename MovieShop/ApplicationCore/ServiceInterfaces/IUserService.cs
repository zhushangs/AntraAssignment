using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel);
        Task<LoginResponseModel> ValidateUser(string email, string password);
        Task<UserProfileResponseModel> GetUserProfile(int id);
        Task<UserProfileResponseModel> Edit(UserProfileRequestModel userProfileRequestModel);
        Task<UserDetailsResponseModel> GetUserById(int id);
        Task<IEnumerable<Movie>> GetUserFavoriteMovies(int id);
        Task<IEnumerable<MovieReviewResponseModel>> GetUserReviews(int id);
        Task<bool> IsFavoriteMovie(int id, int movidId);
        Task DeleteMovieReview(int userId, int movieId);
        Task<IEnumerable<MovieCardResponseModel>> GetAllPurchasedMovie(int id);
        Task<PurchaseResponseModel> PurchaseMovie(PurchaseRequestModel purchaseRequestModel);
        Task AddFavorite(FavoriteRequestModel favoriteRequestModel);
        Task RemoveFavorite(FavoriteRequestModel favoriteRequestModel);
        Task AddReview(ReviewRequestModel reviewRequestModel);
        Task EditReview(ReviewRequestModel reviewRequestModel);
        Task<User> GetUser(string email);
    }
}