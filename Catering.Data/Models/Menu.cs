using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Models
{
    public class Menu
    {
        public Menu()
        {
            Dishes=new List<Dish>();
        }
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
