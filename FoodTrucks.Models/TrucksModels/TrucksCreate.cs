using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class TrucksCreate
    {
        [Required]
        public string Owner { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string FoodType { get; set; }

        [Required]
        public string TruckName { get; set; }
    }
}
