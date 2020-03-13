using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data.Entities
{
    public class RestaurantEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public DateTime? Fundation { get; set; }
        public virtual ICollection<DishEntity> Dishes { get; set; }
    }
}
