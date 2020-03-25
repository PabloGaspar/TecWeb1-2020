using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private RestaurantDbContext dbContext;
        
        public RestaurantRepository(RestaurantDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
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

        public void CreateDish(DishEntity newDish)
        {
            dbContext.Entry(newDish.Restaurant).State = EntityState.Unchanged;
            dbContext.Dishes.Add(newDish);
        }

        public void CreateRestaurant(RestaurantEntity newRestaurant)
        {
            dbContext.Restaurants.Add(newRestaurant);
        }

        public async Task<bool> DeleteDishAsync(int id)
        {
            var dish = await GetDishAsync(id);
            dbContext.Dishes.Remove(dish);
            return true;
        }

        public async Task<bool> DeleteRestaurant(int id)
        {
            var restaurantDelete = await dbContext.Restaurants.FirstOrDefaultAsync( r => r.Id == id);
            dbContext.Restaurants.Remove(restaurantDelete);
            return true;
        }

        public async Task<DishEntity> GetDishAsync(int id)
        {
            IQueryable<DishEntity> query = dbContext.Dishes;
            query = query.Include(d => d.Restaurant);

            query = query.AsNoTracking();
            return await query.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<DishEntity>> GetDishesAsync(int restaurantId)
        {
            IQueryable<DishEntity> query = dbContext.Dishes;
            query = query.AsNoTracking();
            return await query.ToArrayAsync(); ;
        }

        public async Task<RestaurantEntity> GetRestaurantAsync(int id, bool showDishes = false)
        {
            IQueryable<RestaurantEntity> query = dbContext.Restaurants;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<RestaurantEntity>> GetRestaurantsAsync(string orderBy, bool showDishes = false)
        {
            IQueryable<RestaurantEntity> query = dbContext.Restaurants;

            var restaurant = query.FirstOrDefault();

            switch (orderBy)
            {
                case "id":
                    query = query.OrderBy(r => r.Id);
                    break;
                case "name":
                    query = query.OrderBy(r => r.Name);
                    break;
                case "address":
                    query = query.OrderBy(r => r.Address);
                    break;
                default:
                    break;
            }

            if(showDishes)
            {
                query = query.Include(r => r.Dishes);
            }

            query = query.AsNoTracking();

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            var res = await dbContext.SaveChangesAsync();
            return res > 0;
        }

        public bool UpdateDish(DishEntity dish)
        {
            dbContext.Entry(dish.Restaurant).State = EntityState.Unchanged;
            dbContext.Dishes.Update(dish);
            return true;
        }

        public bool UpdateRestaurant(RestaurantEntity restaurant)
        {
            /*var res = dbContext.Restaurants.FirstOrDefault(r => r.Id == restaurant.Id);
            res.Name = restaurant.Name ?? res.Name;
            res.Phone = restaurant.Phone ?? res.Phone;
            res.Address = restaurant.Address ?? res.Address;
            res.Fundation = restaurant.Fundation ?? res.Fundation;*/

            dbContext.Restaurants.Update(restaurant);
            return true;
        }

     
    }
}
