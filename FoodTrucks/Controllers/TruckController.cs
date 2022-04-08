using FoodTrucks.Models;
using FoodTrucks.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrucks.Controllers
{
    [Authorize]
    public class TruckController : Controller
    {

        private TruckServices CreateTruckService()
        {
            return new TruckServices(User.Identity.GetUserId());
        }


        // GET: Truck
        public ActionResult Index()
        {
            var service = CreateTruckService();
            var model = service.GetTrucks();
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TruckCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateTruckService();
                if (service.CreateTruck(model))
                {
                    ViewData["SaveResult"] = "The Truck has been created";
                    return RedirectToAction("Index");
                }
                ViewData["SaveResult"] = "The Truck could not be created";
                return View(model);
            }
            ViewData["SaveResult"] = "Invalid Model State";
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateTruckService();
            var model = service.GetTruckById(id);
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult Delete(int id)
        {
            var service = CreateTruckService();
            var model = service.GetTruckById(id);
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var servicec = CreateTruckService();
            if (servicec.DeleteTruckById(id))
            {
                ViewData["SaveResult"] = "The Truck has been deleted";
            }
            else
            {
                ViewData["SaveResult"] = "The Truck could not be deleted";
            }
            return Redirect("Index");
        }

        public ActionResult Edit (int id)
        {
            var service = CreateTruckService();
            var truck = service.GetTruckById(id);
            var model = new TrucksEdit
            {
                TruckId = truck.TruckId,
                TruckName = truck.TruckName,
                Description = truck.Description,
                Owner = truck.Owner,
                FoodType = truck.FoodType
            };
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrucksEdit model)
        {
            var service = CreateTruckService();
            if (service.EditTruck(model))
            {
                ViewData["SaveResult"] = "The Truck was successfully updated";
            }
            else
            {
                ViewData["SaveResult"] = "The Truck could not be updated";
            }
            return Redirect("Index");
        }
    }
}