using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data
{
    public class Location
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public string Address { get; set; }
        
        public string TimeOpen { get; set; }

        public string TimeClose { get; set; }

        public string DateatLocation { get; set; }

    }
}
