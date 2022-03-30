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
        public int OwnerId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string FoodType { get; set; }



    }
}
