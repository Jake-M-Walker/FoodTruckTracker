using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class LocationEdit
    {
        public int LocationId { get; set; }

        [Required]
        public string LocationName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string TimeOpen { get; set; }

        [Required]
        public string TimeClose { get; set; }

        [Required]
        public bool IsHere { get; set; }

        [Required]
        public string DateatLocation { get; set; }
    }
}
