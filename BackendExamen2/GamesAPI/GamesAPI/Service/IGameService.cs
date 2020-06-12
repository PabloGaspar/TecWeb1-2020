using GamesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesAPI.Service
{
    public interface IGameService
    {
        VideoGame AddVideoGame(VideoGame newGame);
        IEnumerable<VideoGame> GetVideoGames();
        bool DeleteVideoGames(int[] ids);
    }
}
