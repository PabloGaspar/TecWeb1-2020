using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesAPI.Models;
using GamesAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGameService gameService;
        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }
        
        // GET api/games
        [HttpGet]
        public ActionResult<IEnumerable<VideoGame>> Get()
        {
            var videogames = gameService.GetVideoGames();
            return Ok(videogames);
        }

       

        // POST api/games
        [HttpPost]
        public ActionResult Post([FromBody] VideoGame game)
        {
            var createdGame = gameService.AddVideoGame(game);
            return Created("api/games", createdGame);
        }

       //POST api/games/BatchDelete
       [HttpPost("BatchDelete")]
        public ActionResult RemoveGames([FromBody] int[] ids)
        {
            var result = gameService.DeleteVideoGames(ids);
            return Ok(result);
        }
    }
}
