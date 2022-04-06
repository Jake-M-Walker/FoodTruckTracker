using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    class LocationListItem
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string Address { get; set; }

        public DateTimeOffset TimeOpen { get; set; }

        public DateTimeOffset TimeClose { get; set; }

        public bool IsHere { get; set; }

        public DateTimeOffset DateatLocation { get; set; }
    }
}
