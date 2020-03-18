using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        RestaurantModel GetRestaurant(int id);
        Task<IEnumerable<RestaurantModel>> GetRestaurantsAsync(string orderBy = "id", bool showDishes = false);
        Task<RestaurantModel> CreateRestaurantAsync(RestaurantModel newRestaurant);
        bool UpdateRestaurant(int id,RestaurantModel restaurant);
        bool DeleteRestaurant(int id);
    }
}
