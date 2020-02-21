using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantsController : Controller
    {
        [HttpGet]
        public string[] GetReastuarants()
        {
            //IRestauranServe service = new RestaurantService();
            
            return new string[]{ "panchita", "kingdom"};
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
