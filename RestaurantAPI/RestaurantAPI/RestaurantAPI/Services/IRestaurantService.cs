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
        IEnumerable<RestaurantModel> GetRestaurants();
        RestaurantModel CreateRestaurant(RestaurantModel newRestaurant);
        bool UpdateRestaurant(RestaurantModel restaurant);
        bool DeleteRestaurant(int id);
    }
}
