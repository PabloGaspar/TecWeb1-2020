using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantAPI.Data.Entities;
using RestaurantAPI.Data.Repository;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        
        private List<string> allowedSortValues = new List<string>() { "id", "name", "address"};
        private IRestaurantRepository repository;
        private readonly IMapper mapper;

        public RestaurantService(IRestaurantRepository repository, IMapper mapper)
        {
           this.repository = repository;
           this.mapper = mapper;
        }

        public RestaurantModel CreateRestaurant(RestaurantModel newRestaurant)
        {
            var restaurantEntity = mapper.Map<RestaurantEntity>(newRestaurant);
            var newRestaurantEntity = repository.CreateRestaurant(restaurantEntity);
            return mapper.Map<RestaurantModel>(newRestaurantEntity);
        }

        public bool DeleteRestaurant(int id)
        {
            var restaurantToDelete = GetRestaurant(id);
            repository.DeleteRestaurant(id);
            return true;
        }

        public RestaurantModel GetRestaurant(int id)
        {
            var resturantEntity = repository.GetRestaurant(id);
            if (resturantEntity == null)
            {
                throw new NotFoundException($"the id :{id} not exist");
            }
            else
            {
                return mapper.Map<RestaurantModel>(resturantEntity); ;
            }
            
        }

        public IEnumerable<RestaurantModel> GetRestaurants(string orderBy)
        {
            if (!allowedSortValues.Contains(orderBy.ToLower()))
            {
                throw new BadOperationRequest( $"bad sort value: { orderBy } allowed values are: { String.Join(",", allowedSortValues)}");
            }
            var restaurantEntities = repository.GetRestaurants(orderBy);
            return mapper.Map<IEnumerable<RestaurantModel>>(restaurantEntities);
        }

        public bool UpdateRestaurant(int id,RestaurantModel restaurant)
        {
            var restaurantToUpdate = GetRestaurant(id);
            restaurant.Id = id;

            repository.UpdateRestaurant(mapper.Map<RestaurantEntity>(restaurant));
            return true;
        }
    }
}
