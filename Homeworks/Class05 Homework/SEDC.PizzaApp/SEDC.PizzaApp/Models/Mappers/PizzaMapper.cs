using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Enums;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel PizzaToPVM(Pizza pizza)
        {
            PizzaViewModel pvm = new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Size = pizza.Size,
                IsOnSale = pizza.IsOnSale,         
                Price = pizza.Price
            };           

            return pvm;
        }

        //sets the correct Price and SalePrice of the Pizza model, 
        //according to whether the PizzaViewModel is on sale or not
        public static Pizza PVMToPizza(PizzaViewModel pvm)
        {
            Pizza pizza = new Pizza
            {
                Id = pvm.Id,
                Name = pvm.Name,
                Size = pvm.Size,
                IsOnSale = pvm.IsOnSale,
                Price = pvm.Price
            };

            return pizza;
        }
    }
}
