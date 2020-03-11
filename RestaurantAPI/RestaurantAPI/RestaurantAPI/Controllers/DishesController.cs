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
        public ActionResult<bool> DeleteDish(int restaurantId, int id)
        {
            try
            {
                return Ok(service.DeleteDish(restaurantId, id));
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
        public ActionResult<bool> UpdateDish(int restaurantId, int id, [FromBody]DishModel dish)
        {
            try
            {
                return Ok(service.UpdateDish(restaurantId, id, dish));
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
        public ActionResult<DishModel> GetDish(int restaurantId, int id)
        {
            try
            {
                return Ok(service.GetDish(restaurantId, id));
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
        public ActionResult<DishModel> CreateDish(int restaurantId, [FromBody]DishModel dish)
        {
            try
            {
                var newDish = service.CreateDish(restaurantId, dish);
                return Created($"api/restaurants/{restaurantId}/dishes/{newDish.Id}", newDish);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult<DishModel> GetDishes(int restaurantId)
        {
            try
            {
                return Ok(service.GetDishes(restaurantId));

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
