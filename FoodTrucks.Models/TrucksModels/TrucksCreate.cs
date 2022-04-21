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
        [Display(Name = "Owner")]
        public string Owner { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Food Type")]
        public string FoodType { get; set; }

        [Display(Name = "Truck Name")]
        public string TruckName { get; set; }

        [Display(Name = "Current Location")]
        public int? LocationId { get; set; }
    }
}
