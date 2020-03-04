using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private List<RestaurantModel> restaurants = new List<RestaurantModel>();
        private List<string> allowedSortValues = new List<string>() { "id", "name", "address"};

        public RestaurantService()
        {
            restaurants.Add(new RestaurantModel()
            {
                Id = 1,
                Name = "Panchita",
                Address = "Heroinas",
                Fundation = new DateTime(1997, 2, 17),
                Phone = 4444333
            }) ;

            restaurants.Add(new RestaurantModel()
            {
                Id = 2,
                Name = "Kingdom",
                Address = "25 de mayo",
                Fundation = new DateTime(2000, 4, 22),
                Phone = 4449966
            }); 
        }

        public RestaurantModel CreateRestaurant(RestaurantModel newRestaurant)
        {
            var newId = restaurants.OrderByDescending(r => r.Id).First().Id + 1;
            newRestaurant.Id = newId;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public bool DeleteRestaurant(int id)
        {
            var restaurantDelete = GetRestaurant(id);
            restaurants.Remove(restaurantDelete);
            return true;
        }

        public RestaurantModel GetRestaurant(int id)
        {
            var resturant= restaurants.FirstOrDefault(r => r.Id == id);
            if (resturant==null)
            {
                throw new NotFoundException($"the id :{id} not exist");
            }
            else
            {
                return resturant;
            }
            
        }

        public IEnumerable<RestaurantModel> GetRestaurants(string orderBy)
        {
            if (!allowedSortValues.Contains(orderBy.ToLower()))
            {
                throw new BadOperationRequest( $"bad sort value: { orderBy } allowed values are: { String.Join(",", allowedSortValues)}");
                
                // throw new BadOperationRequest() { Message = $"bad sort value: {orderBy} allowed values are: {String.Join(",", allowedSortValues)}"};
            }

            switch (orderBy)
            {
                case "id":
                    return restaurants.OrderBy(r => r.Id);
                case "name":
                    return restaurants.OrderBy(r => r.Name);
                case "address":
                    return restaurants.OrderBy(r => r.Address);
                default:
                    return restaurants;
            }
        }

        public bool UpdateRestaurant(int id,RestaurantModel restaurant)
        {
            var res= GetRestaurant(id);
            res.Name = restaurant.Name??res.Name;
            res.Phone = restaurant.Phone??res.Phone;
            res.Address = restaurant.Address??res.Address;
            res.Fundation = restaurant.Fundation??res.Fundation;
            return true;
        }
    }
}
