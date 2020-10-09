using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel PizzaToViewModel(Pizza pizza)
        {
            int priceIncrease = 0;
            if (pizza.HasExtras)
                priceIncrease = 10;

            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price + priceIncrease,
                PizzaSize = pizza.PizzaSize,
                IsOnPromotion = pizza.IsOnPromotion
            };
        }
    }
}
