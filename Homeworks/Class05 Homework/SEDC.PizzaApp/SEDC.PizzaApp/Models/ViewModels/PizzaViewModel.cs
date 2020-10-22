using SEDC.PizzaApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        
        
        [Display(Name = "Pizza: ")]
        public PizzaType Name { get; set; }

        
        [Display(Name = "Price: ")]
        public decimal Price { get; set; }

        
        [Display(Name = "Is the pizza on sale? ")]
        public bool IsOnSale { get; set; }
        
        
        [Display(Name = "Size: ")]
        public PizzaSize Size { get; set; }
    }
}
