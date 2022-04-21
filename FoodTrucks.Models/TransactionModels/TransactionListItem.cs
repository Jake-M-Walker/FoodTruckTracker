using FoodTrucks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrucks.Models
{
   public class TransactionsListItem
    {
        [Display(Name = "Transaction Id")]
        public int TransactionId { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTimeOffset TransactionDate { get; set; }

        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Display(Name = "Truck Id")]
        public int TruckId { get; set; }

        [Display(Name ="Truck")]
        public string TruckName { get; set; }

        [Display(Name = "Item Id")]
        public int ItemId { get; set; }

        [Display(Name = "Item Bought")]
        public string ItemName { get; set; }


    }
}
