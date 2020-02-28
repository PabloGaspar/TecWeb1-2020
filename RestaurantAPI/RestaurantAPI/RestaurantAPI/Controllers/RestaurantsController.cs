using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantsController : Controller
    {
        private IRestaurantService service;
        
        public RestaurantsController(IRestaurantService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<RestaurantModel> GetReastuarants()
        {
            //IRestauranServe service = new RestaurantService();

            return service.GetRestaurants();
            
        }

        [HttpGet("{id:int}")]
        public string GetRestaurant(int id)
        {
            if (id == 1)
            {
                return "panchita";
            }
            else
            {
                return "kingdom";
            }
        }
    }
}
