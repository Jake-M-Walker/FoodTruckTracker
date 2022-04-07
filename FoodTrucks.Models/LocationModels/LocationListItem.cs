using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class LocationListItem
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string Address { get; set; }

        public string TimeOpen { get; set; }

        public string TimeClose { get; set; }

        public bool IsHere { get; set; }

        public string DateatLocation { get; set; }
    }
}
