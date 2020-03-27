using RestaurantAPI.Auth.Models;
using RestaurantAPI.Models;
using RestaurantAPI.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);
        Task<UserManagerResponse> CreateRoleAsync(CreateRoleViewModel model);

        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
        Task<UserManagerResponse> CreateUserRoleAsync(CreateUserRoleViewModel model);
    }
}
