using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IDishService
    {
        DishModel GetDish(int RestaurantId, int id);
        IEnumerable<DishModel> GetDishes(int RestaurantId);
        DishModel CreateDish(int RestaurantId, DishModel newDish);
        bool UpdateDish(int RestaurantId, int id, DishModel Dish);
        bool DeleteDish(int RestaurantId, int id);
    }
}
