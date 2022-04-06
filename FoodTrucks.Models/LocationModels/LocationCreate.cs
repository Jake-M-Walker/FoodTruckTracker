using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class LocationCreate
    {
        [Required]
        public string LocationName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTimeOffset TimeOpen { get; set; }

        [Required]
        public DateTimeOffset TimeClose { get; set; }

        [Required]
        public bool IsHere { get; set; }

        [Required]
        public DateTimeOffset DateatLocation { get; set; }
    }
}
