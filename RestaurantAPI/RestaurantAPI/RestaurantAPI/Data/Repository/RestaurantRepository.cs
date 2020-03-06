using RestaurantAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private List<RestaurantEntity> restaurants = new List<RestaurantEntity>();

        public RestaurantRepository()
        {
            restaurants.Add(new RestaurantEntity()
            {
                Id = 1,
                Name = "Panchita",
                Address = "Heroinas",
                Fundation = new DateTime(1997, 2, 17),
                Phone = 4444333
            });

            restaurants.Add(new RestaurantEntity()
            {
                Id = 2,
                Name = "Kingdom",
                Address = "25 de mayo",
                Fundation = new DateTime(2000, 4, 22),
                Phone = 4449966
            });
        }
        
        public RestaurantEntity CreateRestaurant(RestaurantEntity newRestaurant)
        {
            var newId = restaurants.OrderByDescending(r => r.Id).First().Id + 1;
            newRestaurant.Id = newId;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public bool DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public RestaurantEntity GetRestaurant(int id, bool showDishes = false)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<RestaurantEntity> GetRestaurants(string orderBy, bool showDishes = false)
        {
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

        public bool UpdateRestaurant(RestaurantEntity restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
