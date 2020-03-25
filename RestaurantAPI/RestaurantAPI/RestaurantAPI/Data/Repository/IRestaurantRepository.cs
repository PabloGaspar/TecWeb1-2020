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
        Task<RestaurantEntity> GetRestaurantAsync(int id, bool showDishes = false);
        Task<IEnumerable<RestaurantEntity>> GetRestaurantsAsync(string orderBy, bool showDishes = false);
        void CreateRestaurant(RestaurantEntity newRestaurant);
        bool UpdateRestaurant(RestaurantEntity restaurant);
        Task<bool> DeleteRestaurant(int id);

        //dishes
        Task<DishEntity> GetDishAsync(int id);
        Task<IEnumerable<DishEntity>> GetDishesAsync(int restaurantId);
        void CreateDish(DishEntity newDish);
        bool UpdateDish(DishEntity Dish);
        Task<bool> DeleteDishAsync(int id);


        //save changes
        Task<bool> SaveChangesAsync();
    }
}
