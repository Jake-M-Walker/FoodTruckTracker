using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class TrucksEdit
    {
        [Display(Name = "Truck Id")]
        public int TruckId { get; set; }

        [Display(Name = "Truck Name")]
        public string TruckName { get; set; }

        public string Owner { get; set; }

        public string Description { get; set; }

        [Display(Name = "Food Type")]
        public string FoodType { get; set; }

        [Display(Name = "Current Location")]
        public int? LocationId { get; set; }
    }
}
