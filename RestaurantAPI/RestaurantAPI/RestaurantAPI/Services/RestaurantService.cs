using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class RestaurantService
    {
        private List<RestaurantModel> restaurants = new List<RestaurantModel>();

        public RestaurantService()
        {
            restaurants.Add(new RestaurantModel()
            {
                Name = "Panchita",
                Address = "Heroinas",
                Fundation = new DateTime(1997, 2, 17),
                Phone = 4444333
            }) ;

            restaurants.Add(new RestaurantModel()
            {
                Name = "Kingdom",
                Address = "25 de mayo",
                Fundation = new DateTime(2000, 4, 22),
                Phone = 4449966
            });
        }
    }
}
