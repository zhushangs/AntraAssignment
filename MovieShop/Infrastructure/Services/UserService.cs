﻿using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Claims;
using System.Security.Cryptography;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using ApplicationCore.Exceptions;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMovieRepository _movieRepository;

        public UserService(IUserRepository userRepository, IFavoriteRepository favoriteRepository, IReviewRepository reviewRepository,
                            IPurchaseRepository purchaseRepository, IMovieRepository movieRepository)
        {
            _userRepository = userRepository;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
            _purchaseRepository = purchaseRepository;
            _movieRepository = movieRepository;
        }
        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            //check user with email exists in DB
            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);
            //if exist
            if (dbUser != null)
            {
                throw new Exception("User exists, try Login");
            }
            //generate a unique salt
            var salt = CreateSalt();
            //hash pw with salt
            var hashedPassword = CreateHashedPassword(userRegisterRequestModel.Password, salt);
            //create user object and save it to DB with userRepository
            var user = new User()
            {
                FirstName = userRegisterRequestModel.FirstName,
                LastName = userRegisterRequestModel.LastName,
                Email = userRegisterRequestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = userRegisterRequestModel.DateOfBirth,
            };
            //call repository
            var createdUser = await _userRepository.AddAsync(user);
            var createdUserResponse = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };
            return createdUserResponse;
        }

        public async Task<LoginResponseModel> ValidateUser(string email, string password)
        {
            var dbUser = await _userRepository.GetUserByEmail(email);
            if (dbUser == null)
            {
                return null;
            }
            var hashedPassword = CreateHashedPassword(password, dbUser.Salt);
            if (hashedPassword == dbUser.HashedPassword)
            {
                //pw match, then create loginResponseModel
                var loginResponseModel = new LoginResponseModel
                {
                    Id = dbUser.Id,
                    Email = dbUser.Email,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                };
                return loginResponseModel;
            }
            return null;
        }
        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public async Task<UserProfileResponseModel> GetUserProfile(int id)
        {
            var user = await _userRepository.GetUserProfileAsync(id);
            var theUser = new UserProfileResponseModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return theUser;
        }

        public async Task<UserProfileResponseModel> Edit(UserProfileRequestModel userProfileRequestModel)
        {
            var salt = CreateSalt();
            var dbUser = await _userRepository.GetUserByEmail(userProfileRequestModel.Email);

            var user = new User()
            {
                Id = userProfileRequestModel.Id,
                Email = userProfileRequestModel.Email,
                FirstName = userProfileRequestModel.FirstName == null ? dbUser.FirstName : userProfileRequestModel.FirstName,
                LastName = userProfileRequestModel.LastName == null ? dbUser.LastName : userProfileRequestModel.LastName,
                Salt = userProfileRequestModel.Password == null ? dbUser.Salt : salt,
                HashedPassword = userProfileRequestModel.Password == null ? dbUser.HashedPassword :
                                CreateHashedPassword(userProfileRequestModel.Password, salt),
                PhoneNumber = userProfileRequestModel.PhoneNumber == null ? dbUser.PhoneNumber : userProfileRequestModel.PhoneNumber,
            };
            var updatedUser = await _userRepository.UpdateAsync(user);
            var updatedUserResponse = new UserProfileResponseModel
            {
                Id = updatedUser.Id,
                Email = updatedUser.Email,
                FirstName = updatedUser.FirstName,
                LastName = updatedUser.LastName
            };
            return updatedUserResponse;

            // return await _userRepository.UpdateAsync(user);
        }

        public async Task<UserDetailsResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new DllNotFoundException("user not exist");
            }
            var userDetails = new UserDetailsResponseModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
            };
            return userDetails;
        }

        public async Task<IEnumerable<Movie>> GetUserFavoriteMovies(int id)
        {
            var movies = await _userRepository.GetUserFavoriteMoviesAsync(id);
            return movies;
        }

        public async Task<IEnumerable<MovieReviewResponseModel>> GetUserReviews(int id)
        {
            var reviews = await _userRepository.GetUserReviewsAsync(id);
            var reviewList = new List<MovieReviewResponseModel>();
            foreach (var review in reviews)
            {
                reviewList.Add(new MovieReviewResponseModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,
                    Rating = review.Rating,
                    ReviewText = review.ReviewText,
                    Title = review.Movie.Title,
                    PosterUrl = review.Movie.PosterUrl,
                    FirstName = review.User.FirstName,
                    LastName = review.User.LastName
                });
            }
            return reviewList;
        }

        public async Task<bool> IsFavoriteMovie(int id, int movidId)
        {
            var isFavorite = await _favoriteRepository.GetExistsAsync(f => f.MovieId == movidId && f.UserId == id);
            return isFavorite;
        }

        public async Task AddFavorite(FavoriteRequestModel favoriteRequestModel)
        {
            var favorite = new Favorite
            {
                UserId = favoriteRequestModel.UserId,
                MovieId = favoriteRequestModel.MovieId,
            };

            await _favoriteRepository.AddAsync(favorite);
        }

        public async Task RemoveFavorite(FavoriteRequestModel favoriteRequestModel)
        {
            var unfavorite = await _favoriteRepository.ListAsync(f => f.MovieId == favoriteRequestModel.MovieId && f.UserId == favoriteRequestModel.UserId);
            await _favoriteRepository.DeleteAsync(unfavorite.First());
        }

        public async Task AddReview(ReviewRequestModel reviewRequestModel)
        {
            var review = new Review
            {
                MovieId = reviewRequestModel.MovieId,
                UserId = reviewRequestModel.UserId,
                Rating = reviewRequestModel.Rating,
                ReviewText = reviewRequestModel.ReviewText,
            };
            await _reviewRepository.AddAsync(review);
        }
        public async Task EditReview(ReviewRequestModel reviewRequestModel)
        {
            var dbReview = _reviewRepository.GetExistsAsync(r => r.MovieId == reviewRequestModel.MovieId && r.UserId == reviewRequestModel.UserId).Result;
            if (!dbReview)
            {
                throw new NotFoundException("Review Not exists");
            }
            var review = new Review
            {
                UserId = reviewRequestModel.UserId,
                MovieId = reviewRequestModel.MovieId,
                Rating = reviewRequestModel.Rating,
                ReviewText = reviewRequestModel.ReviewText,
            };
            await _reviewRepository.UpdateAsync(review);
        }
        public async Task DeleteMovieReview(int userId, int movieId)
        {
            var review = await _reviewRepository.ListAsync(r => r.UserId == userId && r.MovieId == movieId);
            await _reviewRepository.DeleteAsync(review.First());
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetAllPurchasedMovie(int userId)
        {
            var movies = await _purchaseRepository.GetPurchasedMovieByUser(userId);
            var purchaesdMovies = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                purchaesdMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return purchaesdMovies;

        }

        public async Task<PurchaseResponseModel> PurchaseMovie(PurchaseRequestModel purchaseRequestModel)
        {
            var purchase = new Purchase
            {
                MovieId = purchaseRequestModel.MovieId,
                UserId = purchaseRequestModel.UserId,
                PurchaseNumber = purchaseRequestModel.PurchaseNumber,
                PurchaseDateTime = purchaseRequestModel.PurchaseTime,
            };
            var reponse = await _purchaseRepository.AddAsync(purchase);
            var purchaseResponse = new PurchaseResponseModel
            {
                MovieId = reponse.MovieId,
                UserId = reponse.UserId,
                PurchaseNumber = reponse.PurchaseNumber,
                PurchaseTime = reponse.PurchaseDateTime,
                Price = reponse.TotalPrice,
            };
            return purchaseResponse;
        }

        public async Task<User> GetUser(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }
    }
}