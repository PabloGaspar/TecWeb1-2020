using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public interface IDishService
    {
        Task<DishModel> GetDishAsync(int RestaurantId, int id);
        Task<IEnumerable<DishModel>> GetDishesAsync(int RestaurantId);
        Task<DishModel> CreateDishAsync(int RestaurantId, DishModel newDish);
        Task<bool> UpdateDishAsync(int RestaurantId, int id, DishModel Dish);
        Task<bool> DeleteDishAsync(int RestaurantId, int id);
    }
}
