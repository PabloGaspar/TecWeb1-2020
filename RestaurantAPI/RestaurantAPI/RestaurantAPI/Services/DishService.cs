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
        public DishModel CreateDish(int RestaurantId, DishModel newDish)
        {
            ValidateRestaurant(RestaurantId);
            var dishEntity = repository.CreateDish(mapper.Map<DishEntity>(newDish));
            return mapper.Map<DishModel>(dishEntity);
        }

        public bool DeleteDish(int restaurantId, int id)
        {
            var dish=GetDish(restaurantId,id);
            if(dish==null)
            {
                throw new NotFoundException($"Dish {id} does not exist");
            }
            return repository.DeleteDish(id);
        }

        public DishModel GetDish(int RestaurantId, int id)
        {
            ValidateRestaurant(RestaurantId);
            var dish = repository.GetDish(id);
            /*if (dish == null || dish.RestaurantId != RestaurantId)
            {
                throw new NotFoundException($"the id :{id} not exist for dish");
            }*/
           
            return mapper.Map<DishModel>(dish);
        }

        public IEnumerable<DishModel> GetDishes(int restaurantId)
        {
            ValidateRestaurant(restaurantId);
            return mapper.Map<IEnumerable<DishModel>>(repository.GetDishes(restaurantId));
        }

        public bool UpdateDish(int restaurantId, int id, DishModel dish)
        {
            dish.Id = id;
            GetDish(restaurantId, id);
           
            return repository.UpdateDish(mapper.Map<DishEntity>(dish));

        }

        private void ValidateRestaurant(int id)
        {
            var resturantEntity = repository.GetRestaurant(id);
            if (resturantEntity == null)
            {
                throw new NotFoundException($"the id :{id} not exist for restaurant");
            }
        }
    }
}
