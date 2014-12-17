using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Models
{
    public class Dish
    {
        public Dish()
        {
            OrderDishes = new List<OrderDish>();
            MenuDishes=new List<MenuDish>();
        }
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<MenuDish> MenuDishes { get; set; }
        public virtual ICollection<OrderDish> OrderDishes { get; set; } 
    }
}
