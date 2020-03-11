using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(30,ErrorMessage ="Invalid Address Lenght")]
        [Required]
        public string Address { get; set; }
        [Range(1,9999999999999)]
        public int? Phone { get; set; }
        public DateTime? Fundation { get; set; }
        public IEnumerable<DishModel> Dishes { get; set; }
    }
}
