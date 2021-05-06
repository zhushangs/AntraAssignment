using ApplicationCore.Models.Request;
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

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            //check user with email exists in DB
            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);

            //if exist
            if(dbUser != null)
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
            if(dbUser == null)
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
    }
}
