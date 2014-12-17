using System;

namespace Catering.Data.Models
{
    public class MenuDish
    {
        public int Id { get; set; } 
        public Menu Menu { get; set; }
        public Dish Dish { get; set; }
        public DateTime DateTime { get; set; }  
    }
}