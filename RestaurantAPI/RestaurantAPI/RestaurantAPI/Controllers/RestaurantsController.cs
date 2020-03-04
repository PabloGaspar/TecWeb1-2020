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
    //[ApiController]
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
            try
            {
                return Ok(service.GetRestaurant(id));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<RestaurantModel> CreateRestaurant([FromBody] RestaurantModel restaurant)
        {
            try
            {
                var newRestaurant = service.CreateRestaurant(restaurant);
                return Created($"/api/Restaurants/{newRestaurant.Id}", newRestaurant);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteRestaurant(int id)
        {
            try
            {
                var res = service.DeleteRestaurant(id);
                return Ok(res);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult<bool> UpdateRestaurant(int id, RestaurantModel restaurant)
        {
            try
            {
     
                return Ok(service.UpdateRestaurant(id,restaurant));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
    }
}
