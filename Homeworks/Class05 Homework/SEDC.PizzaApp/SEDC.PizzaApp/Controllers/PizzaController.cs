using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Enums;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<PizzaViewModel> pizzaList = StaticDb.Pizzas.Select(x=>PizzaMapper.PizzaToPVM(x));
            
            return View(pizzaList); 
        }

        public IActionResult JsonData()
        {
            Pizza pizza = new Pizza
            {
                Id = 1,
                Name = PizzaType.Kapri
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
                return View();
            }
            //  return new EmptyResult();
            return View("BadRequest");
        }

        public IActionResult CreatePizza()
        {
            PizzaViewModel pizzavm = new PizzaViewModel();
            return View(pizzavm);
        }


        [HttpPost]
        public IActionResult CreatePizzaPost(PizzaViewModel pvm)
        {
            if(pvm.Name==0 || pvm.Size==0 || pvm.Price==0)
            {
                return View("BadRequest");
            }

            Pizza pizza = new Pizza();
            pizza = PizzaMapper.PVMToPizza(pvm);
            pizza.Id = (StaticDb.Pizzas.Count) + 1;
            StaticDb.Pizzas.Add(pizza);
            return RedirectToAction("Index");
            
        }

        public IActionResult EditPizza(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if(pizza == null)
            {
                return View("ResourceNotFound");
            }

            PizzaViewModel pvm = PizzaMapper.PizzaToPVM(pizza);
            
            return View(pvm);
        }

        [HttpPost]
        public IActionResult EditPizzaPost(PizzaViewModel pvm)
        {
            //try
            //{
                Pizza pizza = PizzaMapper.PVMToPizza(pvm);
                if(pizza == null)
                {
                    return View("ResourceNotFound");
                }
                int index = StaticDb.Pizzas.FindIndex(x => x.Id == pizza.Id);
                StaticDb.Pizzas[index] = pizza;
                return RedirectToAction("Index");
                
            //}
            //catch
            //{
                //return View("InternalServerError");
            //}
        }

        public IActionResult DeletePizza(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                return View("ResourceNotFound");
            }

            PizzaViewModel pvm = PizzaMapper.PizzaToPVM(pizza);

            return View(pvm);
        }

        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                return View("ResourceNotFound");
            }

            foreach(Order order in StaticDb.Orders)
            {
                if(order.Pizza.Id==pizza.Id)
                {
                    return View("Forbidden");
                }
            }

            StaticDb.Pizzas.RemoveAll(x => x.Id == pizza.Id);

            return RedirectToAction("Index");
        }
    }
}