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
    public class MenuItemController : Controller
    {

        private MenuItemServices CreateMenuItemService()
        {
            return new MenuItemServices(User.Identity.GetUserId());
        }


        // GET: MenuItem
        public ActionResult Index()
        {
            var service = CreateMenuItemService();
            var model = service.GetMenuItems();
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuItemCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateMenuItemService();
                if (service.CreateMenuItem(model))
                {
                    ViewData["SaveResult"] = "The Menu Item has been created";
                    return RedirectToAction("Index");
                }
                ViewData["SaveResult"] = "The Menu Item could not be created";
                return View(model);
            }
            ViewData["SaveResult"] = "Invalid Model State";
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateMenuItemService();
            var model = service.GetMenuItemById(id);
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        public ActionResult Delete(int id)
        {
            var service = CreateMenuItemService();
            var model = service.GetMenuItemById(id);
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
            var service = CreateMenuItemService();
            if (service.DeleteMenuItemById(id))
            {
                ViewData["SaveResult"] = "The Menu Item has been deleted";
            }
            else
            {
                ViewData["SaveResult"] = "The Menu Item could not be deleted";
            }
            return Redirect("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMenuItemService();
            var menuitem = service.GetMenuItemById(id);
            var model = new MenuItemEdit
            {
                ItemId = menuitem.ItemId,
                ItemName = menuitem.ItemName,
                ItemDescription = menuitem.ItemDescription,
                ItemPrice = menuitem.ItemPrice,
                CostforTruck = menuitem.CostforTruck,
                TruckId = menuitem.TruckId,
            };
            if(model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MenuItemEdit model)
        {
            var service = CreateMenuItemService();
            if (service.EditMenuItem(model))
            {
                ViewData["SaveResult"] = "The Menu Item was successfully updated";
            }
            else
            {
                ViewData["SaveResult"] = "The Menu Item could not be updated";
            }
            return Redirect("Index");
        }
    }
}