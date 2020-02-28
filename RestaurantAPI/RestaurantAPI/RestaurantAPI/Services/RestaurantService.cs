using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private List<RestaurantModel> restaurants = new List<RestaurantModel>();

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
            throw new NotImplementedException();
        }

        public bool DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public RestaurantModel GetRestaurant(int id)
        {
            return restaurants.FirstOrDefault( r => r.Id == id);
        }

        public IEnumerable<RestaurantModel> GetRestaurants()
        {
            return restaurants;
        }

        public bool UpdateRestaurant(RestaurantModel restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
