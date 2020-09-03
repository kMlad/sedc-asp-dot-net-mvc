using SEDC.PizzaApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<int> IDsOfPizzasOrdered { get; set; }
        public int Price { get; set; }

        public Order(int id, List<int> PizzaIDs, int price)
        {
            this.Id = id;
            this.IDsOfPizzasOrdered = PizzaIDs;
            this.Price = price;
        }          



    }

}
