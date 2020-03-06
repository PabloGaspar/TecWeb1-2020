using RestaurantAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Repository
{
    public interface IRestaurantRepository
    {
        RestaurantEntity GetRestaurant(int id, bool showDishes = false);
        IEnumerable<RestaurantEntity> GetRestaurants(string orderBy, bool showDishes = false);
        RestaurantEntity CreateRestaurant(RestaurantEntity newRestaurant);
        bool UpdateRestaurant(RestaurantEntity restaurant);
        bool DeleteRestaurant(int id);
    }
}
