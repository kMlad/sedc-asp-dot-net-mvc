using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<PizzaViewModel> pizzaViewModels = new List<PizzaViewModel>();
            foreach (Pizza pizza in StaticDb.Pizzas)
            {
                pizzaViewModels.Add(PizzaMapper.PizzaToViewModel(pizza));
            }

            return View(pizzaViewModels); // returns ViewResult
        }

        public IActionResult JsonData()
        {
            Pizza pizza = new Pizza
            {
                Id = 1,
                Name = "Capri"
            };
            return new JsonResult(pizza); // returns JsonResult
        }

        public IActionResult BackToHome()
        {
            return RedirectToAction("Index", "Home"); //redirects to Action Index in Home Controller
        }

        public IActionResult Details(int? id) // localhost:port/Pizza/Details/1 or  localhost:port/Pizza/Details
        {
            if (id != null)
            {
                int trueID = id.Value;
                Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == trueID);
                return View(PizzaMapper.PizzaToViewModel(pizza));
            }
            //  return new EmptyResult();
            return View("BadRequest");
        }
    }
}