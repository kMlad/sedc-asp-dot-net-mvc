using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp.Models.Domain
{
    public class Pizza
    {
       
        public int Id { get; set; }
        public PizzaType Name { get; set; }
        public decimal Price { get; set; }
        public bool IsOnSale { get; set; }
        public PizzaSize Size { get; set; }
        
    }
}
