using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Exceptions;
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

        [HttpGet()]
        public ActionResult<IEnumerable<RestaurantModel>> GetReastuarants(string orderBy = "id")
        {
            //IRestauranServe service = new RestaurantService();
            try
            {
                return Ok(service.GetRestaurants(orderBy));
            }
            catch(BadOperationRequest ex) 
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            
            
        }

        [HttpGet("{id:int}")]
        public ActionResult<RestaurantModel> GetRestaurant(int id)
        {
           return Ok(service.GetRestaurant(id));
        }
    }
}
