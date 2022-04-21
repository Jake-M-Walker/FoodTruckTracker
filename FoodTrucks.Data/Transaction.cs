using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public DateTimeOffset TransactionDate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        
        [ForeignKey("Truck")]
        public int TruckId { get; set; }
        public virtual Truck Truck { get; set; }


        [ForeignKey("MenuItem")]
        public int ItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }

        public int NumberBought { get; set; }

        public decimal TotalCost { get { return NumberBought * MenuItem.ItemPrice; } }
    }
}
