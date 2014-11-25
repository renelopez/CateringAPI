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
            Orders = new List<Order>();
            Menus=new List<Menu>();
        }
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Menu> Menus { get; set; } 
    }
}
