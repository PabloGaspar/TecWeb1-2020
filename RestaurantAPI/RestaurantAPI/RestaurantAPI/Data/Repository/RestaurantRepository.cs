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
        private List<DishEntity> dishes = new List<DishEntity>();

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

            dishes.Add(new DishEntity() { 
                Id = 1,
                Name = "panchicono",
                Price = 25.5m,
                Description = "un cono",
                //RestaurantId = 1

            });
            dishes.Add(new DishEntity()
            {
                Id = 2,
                Name = "chipollo",
                Price = 40.3m,
                Description = "un chipollo",
               // RestaurantId = 1

            });

            dishes.Add(new DishEntity()
            {
                Id = 3,
                Name = "queen Menu",
                Price = 35.7m,
                Description = "queen",
                //RestaurantId = 2

            });

            dishes.Add(new DishEntity()
            {
                Id = 4,
                Name = "king Menu",
                Price = 45.7m,
                Description = "king",
               // RestaurantId = 2

            });
        }

        public DishEntity CreateDish(DishEntity newDish)
        {
            var newId = dishes.OrderByDescending(d => d.Id).FirstOrDefault().Id + 1;
            newDish.Id = newId;
            dishes.Add(newDish);
            return newDish;
        }

        public RestaurantEntity CreateRestaurant(RestaurantEntity newRestaurant)
        {
            var newId = restaurants.OrderByDescending(r => r.Id).First().Id + 1;
            newRestaurant.Id = newId;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public bool DeleteDish(int id)
        {
            var dish = GetDish(id);
            return dishes.Remove(dish);
        }

        public bool DeleteRestaurant(int id)
        {
            var restaurantDelete = GetRestaurant(id);
            restaurants.Remove(restaurantDelete);
            return true;
        }

        public DishEntity GetDish(int id)
        {
            return dishes.SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<DishEntity> GetDishes(int restaurantId)
        {
            //return dishes.Where(d => d.RestaurantId == restaurantId);
            return null;
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

        public bool UpdateDish(DishEntity dish)
        {
            var res = GetDish(dish.Id);
            res.Name = dish.Name;
            res.Price = dish.Price;
            res.Description = dish.Description;
            return true;
            
        }

        public bool UpdateRestaurant(RestaurantEntity restaurant)
        {
            var res = GetRestaurant(restaurant.Id);
            res.Name = restaurant.Name ?? res.Name;
            res.Phone = restaurant.Phone ?? res.Phone;
            res.Address = restaurant.Address ?? res.Address;
            res.Fundation = restaurant.Fundation ?? res.Fundation;
            return true;
        }
    }
}
