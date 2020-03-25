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
        public async Task<ActionResult<IEnumerable<RestaurantModel>>> GetReastuarants(string orderBy = "id", bool showDishes = false)
        {
            //IRestauranServe service = new RestaurantService();
            try
            {
                return Ok(await service.GetRestaurantsAsync(orderBy, showDishes));
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
        public async Task<ActionResult<RestaurantModel>> GetRestaurant(int id)
        {
            try
            {
                return Ok(await service.GetRestaurantAsync(id));
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
        public async Task<ActionResult<RestaurantModel>> CreateRestaurant([FromBody] RestaurantModel restaurant)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                var newRestaurant = await service.CreateRestaurantAsync(restaurant);
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
        public async Task<ActionResult<bool>> DeleteRestaurantAsync(int id)
        {
            try
            {
                var res = await service.DeleteRestaurantAsync(id);
                return Ok(res);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateRestaurant(int id, [FromBody] RestaurantModel restaurant)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        if (state.Key == nameof(restaurant.Address) && state.Value.Errors.Count > 0)
                        {
                            return BadRequest(state.Value.Errors);
                        }
                    }
                }

                return Ok(await service.UpdateRestaurantAsync(id,restaurant));
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
