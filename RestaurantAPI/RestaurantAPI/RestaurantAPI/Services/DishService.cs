using AutoMapper;
using RestaurantAPI.Data.Entities;
using RestaurantAPI.Data.Repository;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Services
{
    public class DishService : IDishService
    {
        private IRestaurantRepository repository;
        private IMapper mapper;

        public DishService(IRestaurantRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DishModel> CreateDishAsync(int RestaurantId, DishModel newDish)
        {
            await ValidateRestaurantAsync(RestaurantId);
            newDish.RestaurantId = RestaurantId;
            var dishEntity = mapper.Map<DishEntity>(newDish);
            
            repository.CreateDish(dishEntity);

            var res = await repository.SaveChangesAsync();
            if (res)
            {
                return mapper.Map<DishModel>(dishEntity); 
            }

            throw new Exception("Database Exception");
        }

        public async Task<bool> DeleteDishAsync(int restaurantId, int id)
        {
            var dish = await GetDishAsync(restaurantId,id);
            if(dish==null)
            {
                throw new NotFoundException($"Dish {id} does not exist");
            }
            await repository.DeleteDishAsync(id);
            var res = await repository.SaveChangesAsync();
            if (res)
            {
                return true;
            }

            throw new Exception("Database Exception");
        }

        public async Task<DishModel> GetDishAsync(int RestaurantId, int id)
        {
            await ValidateRestaurantAsync(RestaurantId);
            var dish = await repository.GetDishAsync(id);
            if (dish == null || dish.Restaurant.Id != RestaurantId)
            {
                throw new NotFoundException($"the id :{id} not exist for dish");
            }
           
            return mapper.Map<DishModel>(dish);
        }

        public async Task<IEnumerable<DishModel>> GetDishesAsync(int restaurantId)
        {
            await ValidateRestaurantAsync(restaurantId);
            return mapper.Map<IEnumerable<DishModel>>(await repository.GetDishesAsync(restaurantId));
        }

        public async Task<bool> UpdateDishAsync(int restaurantId, int id, DishModel dish)
        {
            dish.Id = id;
            await GetDishAsync(restaurantId, id);

            repository.UpdateDish(mapper.Map<DishEntity>(dish));

            var res = await repository.SaveChangesAsync();
            if (res)
            {
                return true;
            }

            throw new Exception("Database Exception");
        }

        private async Task ValidateRestaurantAsync(int id)
        {
            var resturantEntity = await repository.GetRestaurantAsync(id);
            if (resturantEntity == null)
            {
                throw new NotFoundException($"the id :{id} not exist for restaurant");
            }
        }
    }
}
