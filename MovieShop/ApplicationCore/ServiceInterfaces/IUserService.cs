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

    }
}
