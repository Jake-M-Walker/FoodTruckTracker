using FoodTrucks.Data;
using FoodTrucks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrucks.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        //Get: Transaction/Create
        public ActionResult Create()
        {
            var context = new ApplicationDbContext();
            ViewData["MenuItems"] = context.MenuItems.AsEnumerable().Select(menuitems => new SelectListItem
            {
                Text = menuitems.ItemName,
                Value = menuitems.ItemId.ToString()
            });
            ViewData["Trucks"] = context.Trucks.AsEnumerable().Select(truck => new SelectListItem
            {
                Text = truck.TruckName,
                Value = truck.TruckId.ToString()
            }).ToArray();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transactions model)
        {
            var context = new ApplicationDbContext();

            ViewData["MenuItems"] = context.MenuItems.AsEnumerable().Select(menuitems => new SelectListItem
            {
                Text = menuitems.ItemName,
                Value = menuitems.ItemId.ToString()
            });
            ViewData["Trucks"] = context.Trucks.AsEnumerable().Select(truck => new SelectListItem
            {
                Text = truck.TruckName,
                Value = truck.TruckId.ToString()
            }).ToArray();

            if(context.MenuItems.Find(model.ItemId) == null)
            {
                ViewData["Error"] = "Invalid Item Id";
                return View();
            }
            else if (context.Trucks.Find(model.TruckId) == null)
            {
                ViewData["Error"] = "Invalid Truck Id";
                return View();
            }
            model.TransactionDate = DateTime.Now;
            context.Transactions.Add(model);
            if (context.SaveChanges() == 1)
            {
                return Redirect("/Transaction");
            }
            return View(model);


        }
    }
}