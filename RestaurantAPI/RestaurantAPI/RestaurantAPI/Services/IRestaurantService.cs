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
        IEnumerable<RestaurantModel> GetRestaurants(string orderBy = "id");
        RestaurantModel CreateRestaurant(RestaurantModel newRestaurant);
        bool UpdateRestaurant(int id,RestaurantModel restaurant);
        bool DeleteRestaurant(int id);
    }
}
