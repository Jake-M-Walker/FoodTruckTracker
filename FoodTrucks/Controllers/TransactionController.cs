using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrucks.Models;
using FoodTrucks.Services;
using Microsoft.AspNet.Identity;

namespace FoodTrucks.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {

        private TransactionServices CreateTransactionService()
        {
            return new TransactionServices(User.Identity.GetUserId());
        }

        // GET: Transaction
        public ActionResult Index()
        {
            var service = CreateTransactionService();
            var model = service.GetTransactions();
            return View(model);
        }

        public ActionResult Create()
        {
            var context = new ApplicationDbContext();
            ViewData["Trucks"] = context.Trucks.AsEnumerable().Select(truck => new SelectListItem
            {
                Text = truck.TruckName,
                Value = truck.TruckId.ToString()
            });
            ViewData["MenuItems"] = context.MenuItems.AsEnumerable().Select(item => new SelectListItem
            {
                Text = item.ItemName + "-" + item.ItemPrice,
                Value = item.ItemId.ToString()
            });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateTransactionService();
                if (service.CreateTransaction(model))
                {
                    ViewData["SaveResult"] = "The Transaction was created";
                    return RedirectToAction("Index");
                }
                ViewData["SaveResult"] = "The Transaction was not created";
                return View(model);
            }
            ViewData["SaveResult"] = "Invalid Model State";
            return View(model);
        }





public ActionResult Details(int id)
        {
            var service = CreateTransactionService();
            var model = service.GetTransactionById(id);
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult Delete(int id)
        {
            var service = CreateTransactionService();
            var model = service.GetTransactionById(id);
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost (int id)
        {
            var service = CreateTransactionService();
            if (service.DeleteTransactionById(id))
            {
                ViewData["SaveResult"] = "The Transaction was deleted";
            }
            else
            {
                ViewData["SaveResult"] = "The Transaction could not be deleted";
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit (int id)
        {
            var service = CreateTransactionService();
            var transaction = service.GetTransactionById(id);
            var context = new ApplicationDbContext();
            ViewData["Trucks"] = context.Trucks.AsEnumerable().Select(truck => new SelectListItem
            {
                Text = truck.TruckName,
                Value = truck.TruckId.ToString()
            });
            ViewData["MenuItems"] = context.MenuItems.AsEnumerable().Select(item => new SelectListItem
            {
                Text = item.ItemName + "-" + item.ItemPrice,
                Value = item.ItemId.ToString()
            });
            var model = new TransactionEdit
            {
                TransactionId = transaction.TransactionId,
                TransactionDate = transaction.TransactionDate,
                UserId = transaction.UserId,
                TruckId = transaction.TruckId,
                ItemId = transaction.ItemId,
                NumberBought = transaction.NumberBought,
                TotalCost = transaction.TotalCost
            };
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEdit model)
        {
            var service = CreateTransactionService();
            if (service.EditTransaction(model))
            {
                ViewData["SaveResult"] = "The Transaction was successfully edited";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["SaveResult"] = "The Transactoin was not edited";
            }
            return View(model);
        }
    }
}