using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesAPI.Models
{
    public class VideoGame
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsSoldOut { get; set; }
    }
}
