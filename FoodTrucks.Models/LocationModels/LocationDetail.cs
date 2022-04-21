using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class LocationDetail
    {
        [Display(Name = "Location Id")]
        public int LocationId { get; set; }

        [Display(Name = "Location Name")]
        public string LocationName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Time Opened")]
        public string TimeOpen { get; set; }

        [Display(Name = "Time Closed")]
        public string TimeClose { get; set; }

        [Display(Name = "Currently Here")]
        public IEnumerable<LocationDetailTruck> IsHere { get; set; }

        [Display(Name = "Date at Location")]
        public string DateatLocation { get; set; }

      
    }
    public class LocationDetailTruck
    {
        public int TruckId { get; set; }

        public string TruckName { get; set; }
    }
}
