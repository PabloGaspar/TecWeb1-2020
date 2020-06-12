using GamesAPI.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesAPI.Service
{
    public class GameService : IGameService
    {
        private List<VideoGame> videoGames = new List<VideoGame>();

        public GameService()
        {
            videoGames.Add(new VideoGame()
            {
                id = 1, 
                Name = "Dark Souls",
                Price = 39.5m,
                IsSoldOut = true
                
            });

            videoGames.Add(new VideoGame()
            {
                id = 2,
                Name = "booldborne",
                Price = 49.5m,
                IsSoldOut = false

            });

            videoGames.Add(new VideoGame()
            {
                id = 3,
                Name = "demon Souls",
                Price = 20.5m,
                IsSoldOut = true

            });

            videoGames.Add(new VideoGame()
            {
                id = 4,
                Name = "Sekiro",
                Price = 69.5m,
                IsSoldOut = false

            });
        }
        public VideoGame AddVideoGame(VideoGame newGame)
        {
            var nextId = videoGames.OrderByDescending(g => g.id).FirstOrDefault().id++;
            newGame.id = nextId;
            videoGames.Add(newGame);
            return newGame;
        }

        public bool DeleteVideoGames(int[] ids)
        {
            var gamesToRemove = videoGames.Where(g => Array.IndexOf(ids, g.id) > -1).ToList() ;

            foreach (var game in gamesToRemove)
            {
                videoGames.Remove(game);
            }

            return true;
        }

        public IEnumerable<VideoGame> GetVideoGames()
        {
            return videoGames;
        }
    }
}
