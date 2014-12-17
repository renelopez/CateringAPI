using System;

namespace Catering.Data.Models
{
    public class OrderDish
    {
        public int Id { get; set; } 
        public Order Order { get; set; }
        public Dish Dish { get; set; }
        public DateTime DateTime { get; set; }  
    }
}