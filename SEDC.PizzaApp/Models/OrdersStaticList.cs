using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models
{
    public static class OrdersStaticList
    {
        public static List<Order> orders = new List<Order>()
        {
            new Order(1, new List<int>() { 1, 2, 3 }, 1500),
            new Order(2, new List<int>() { 1, 3 }, 999),
            new Order(3, new List<int>() { 3, 7 }, 2000),
        };       

    }
}
