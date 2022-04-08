using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using FoodTrucks.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodTrucks.Models
{
    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Locations> Locations { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Trucks> Trucks { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}