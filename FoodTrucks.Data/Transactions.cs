using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Data
{
    public class Transactions
    {
        [Key]
        [Required]
        public int TransactionId { get; set; }

        [Required]
        public DateTimeOffset TransactionDate { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Trucks))]
        public int TruckId { get; set; }

        public virtual Trucks Truck { get; set; }



        public virtual ICollection<Menu> MenutItems { get; set; }
    }
}
