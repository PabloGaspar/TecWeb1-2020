using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurants/{restaurantId:int}/[controller]")]
    public class DishesController : Controller
    {
        private IDishService service;
        public DishesController(IDishService service)
        {
            this.service = service;
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDishAsync(int restaurantId, int id) // you can return an IActionResult
        {
            try
            {
                return Ok(await service.DeleteDishAsync(restaurantId, id));
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateDishAsync(int restaurantId, int id, [FromBody]DishModel dish)
        {
            try
            {
                return Ok(await service.UpdateDishAsync(restaurantId, id, dish));
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DishModel>> GetDishAsync(int restaurantId, int id)
        {
            try
            {
                return Ok(await service.GetDishAsync(restaurantId, id));
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

        [HttpPost]
        public async Task<ActionResult<DishModel>> CreateDishAsync(int restaurantId, [FromBody]DishModel dish)
        {
            try
            {
                var newDish = await service.CreateDishAsync(restaurantId, dish);
                return Created($"api/restaurants/{restaurantId}/dishes/{newDish.Id}", newDish);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<DishModel>> GetDishesAsync(int restaurantId)
        {
            try
            {
                return Ok(await service.GetDishesAsync(restaurantId));

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
