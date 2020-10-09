using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            ViewData.Add("IndexTitle", "This is the Index Action of the Pizza Controller");
            List<Pizza> pizzas = StaticDb.Pizzas;
            List<PizzaViewModel> pizzaVMs = new List<PizzaViewModel>();
            foreach(Pizza pizza in pizzas)
            {
                pizzaVMs.Add(PizzaMapper.PizzaToViewModel(pizza));
            }
            return View(pizzaVMs); // returns ViewResult
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
            ViewData.Add("DetailsTitle", "This is the Details Action of the Pizza Controller");
            if (id != null)
            {
                int newId = id.Value;
                Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == newId);
                ViewBag.Id = pizza.Id;
                ViewBag.Name = pizza.Name;
                ViewBag.PizzaSize = pizza.PizzaSize;
                ViewBag.Price = pizza.Price;
                return View(ViewBag);
            }
            return new EmptyResult();
        }
    }
}