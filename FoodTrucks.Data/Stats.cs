using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data
{
    public class Stats
    {
        [ForeignKey(nameof(Locations))]
        public int LocationId { get; set; }
        public virtual Locations Locations { get; set; }

        public int NumberofSales { get; set; }

        public decimal ProitLoss { get; set; }

    }
}
