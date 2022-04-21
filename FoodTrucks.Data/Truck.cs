using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data
{
    public class Truck
    {
        public int TruckId { get; set; }

        public string TruckName { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Owner { get; set; }

        public string Description { get; set; }

        public string FoodType { get; set; }

        [ForeignKey("Location")]
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }


    }
}
