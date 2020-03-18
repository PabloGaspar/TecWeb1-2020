using RestaurantAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Repository
{
    public interface IRestaurantRepository
    {
        //restaurants
        RestaurantEntity GetRestaurant(int id, bool showDishes = false);
        Task<IEnumerable<RestaurantEntity>> GetRestaurantsAsync(string orderBy, bool showDishes = false);
        void CreateRestaurant(RestaurantEntity newRestaurant);
        bool UpdateRestaurant(RestaurantEntity restaurant);
        bool DeleteRestaurant(int id);

        //dishes
        DishEntity GetDish(int id);
        IEnumerable<DishEntity> GetDishes(int restaurantId);
        DishEntity CreateDish(DishEntity newDish);
        bool UpdateDish(DishEntity Dish);
        bool DeleteDish(int id);


        //save changes
        Task<bool> SaveChangesAsync();
    }
}
