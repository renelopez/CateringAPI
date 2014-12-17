﻿using System;
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
            MenuDishes=new List<MenuDish>();
        }
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual ICollection<MenuDish> MenuDishes { get; set; }
    }
}
