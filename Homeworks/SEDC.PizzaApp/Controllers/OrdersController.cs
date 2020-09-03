using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Order CorrectOrder = OrdersStaticList.orders.ElementAt((int)id - 1);
                return new JsonResult(CorrectOrder);
            }
            return new EmptyResult();
        }

        public IActionResult JsonData()
        {
            Order order1 = new Order(1, new List<int>() { 1, 2, 3 }, 1500);
            return new JsonResult(order1);
        }

        public IActionResult Redirect()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
