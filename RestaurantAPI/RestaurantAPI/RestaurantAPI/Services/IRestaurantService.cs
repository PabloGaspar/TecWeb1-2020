using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        Task<RestaurantModel> GetRestaurantAsync(int id);
        Task<IEnumerable<RestaurantModel>> GetRestaurantsAsync(string orderBy = "id", bool showDishes = false);
        Task<RestaurantModel> CreateRestaurantAsync(RestaurantModel newRestaurant);
        Task<bool> UpdateRestaurantAsync(int id,RestaurantModel restaurant);
        Task<bool> DeleteRestaurantAsync(int id);
    }
}
