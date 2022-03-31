using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data
{
    public class Trucks
    {
        [Key]
        [Required]
        public int TruckId { get; set; }

        [Required]
        public string TruckName { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Owner { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string FoodType { get; set; }


        public virtual ICollection<Locations> Locations { get; set; }

        public virtual ICollection<MenuItems> MenuItems { get; set; }


    }
}
