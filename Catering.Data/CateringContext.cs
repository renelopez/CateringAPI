using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Data.Models;

namespace Catering.Data.DataLayer
{
    public class CateringContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public System.Data.Entity.DbSet<Catering.Data.Models.Order> Orders { get; set; }
    }
}
