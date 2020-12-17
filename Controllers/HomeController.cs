using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using delicious.Models;
using delicious.Contexts;

namespace delicious.Controllers
{
    public class HomeController : Controller
    {
        private DishContext dbContext;
        public HomeController(DishContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.OrderByDescending(n => n.CreatedAt)
            .ToList();

            ViewBag.Dish = AllDishes;
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreateDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Dish");
            }
        }

        //Loads the new dish page.

        [HttpGet("new")]

        public IActionResult Dish()
        {
            return View();
        }

        //Loads the edit dish page.

        [HttpGet("edit/{dishID}")]
        public IActionResult Edit(int dishID)
        {
            Dish Edit = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishID);

            return View(Edit);
        }


        [HttpPost("update/{dishID}")]

        public IActionResult Update(int dishID, Dish update)
        {
            Dish UpdateDish = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishID);
            if (ModelState.IsValid)
            {
                UpdateDish.Name = update.Name;
                UpdateDish.Chef = update.Chef;
                UpdateDish.Calories = update.Calories;
                UpdateDish.Tastiness = update.Tastiness;
                UpdateDish.Description = update.Description;
                dbContext.SaveChanges();

                return Redirect($"/{dishID}");
            }
            else
            {
                update.DishId = dishID;
                return View("Edit", update);
            }

        }




        //Shows Single Dish

        [HttpGet("{dishID}")]
        public IActionResult OneDish(int dishID)
        {
            Dish Show = dbContext.Dishes.FirstOrDefault(d => d.DishId == dishID);

            return View(Show);
        }


        //Removes Single Dish


        [HttpGet("delete/{dishID}")]
        public IActionResult DeleteDish(int dishID)
        {
            Dish RetDish = dbContext.Dishes.SingleOrDefault(d => d.DishId == dishID);

            dbContext.Dishes.Remove(RetDish);

            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }









        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
