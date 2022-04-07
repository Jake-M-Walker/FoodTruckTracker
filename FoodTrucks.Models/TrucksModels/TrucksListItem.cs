using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
    public class TrucksListItem
    {
        public int TruckId { get; set; }

        public string TruckName { get; set; }

        public string Owner { get; set; }

        public string Description { get; set; }

        public string FoodType { get; set; }
    }
}
