using FoodTrucks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using FoodTrucks.Models;

namespace FoodTrucks.Controllers
{
    [Authorize]
    public class LocationsController : Controller
    {

        private LocationServices CreateLocationService()
        {
            return new LocationServices(User.Identity.GetUserId());
        }

        // GET: Locations
        public ActionResult Index()
        {
            var service = CreateLocationService();
            var model = service.GetLocations();
            return View(model);
        }

        //Get
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateLocationService();
                if (service.CreateLocation(model))
                {
                    ViewData["SaveResult"] = "The Location has been created";
                    return RedirectToAction("Index");
                }
                ViewData["SaveResult"] = "The Location could not be created";
                return View(model);
            }
            ViewData["SaveResult"] = "Invalid Model State";
            return View(model);
        }

        public ActionResult Details (int id)
        {
            var service = CreateLocationService();
            var model = service.GetLocationById(id);
            if (model != null)
            {
                ViewData["Trucks"] = model.IsHere;
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult Delete(int id)
        {
            var service = CreateLocationService();
            var model = service.GetLocationById(id);
            if (model != null)
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
            var service = CreateLocationService();
            if (service.DeleteLocationById(id))
            {
                ViewData["SaveResult"] = "The Location has been deleted";

            }
            else
            {
                ViewData["SaveResult"] = "The Location could not be deleted";
            }
            return RedirectToAction("Index");

        }

        public ActionResult Edit (int id)
        {
            var service = CreateLocationService();
            var location = service.GetLocationById(id);
            var model = new LocationEdit
            {
                LocationId = location.LocationId,
                LocationName = location.LocationName,
                Address = location.Address,
                TimeOpen = location.TimeOpen,
                TimeClose = location.TimeClose,
                DateatLocation = location.DateatLocation,
            };
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationEdit model)
        {
            var service = CreateLocationService();
            if (service.EditLocation(model))
            {
                ViewData["SaveResult"] = "Location was successfully updated";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["SaveResult"] = "Location could not be updated";
            }
            return RedirectToAction("Index");
        }
    }
}