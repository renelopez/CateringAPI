using System.Data.Entity;
using Catering.Data.Models;

namespace Catering.Data
{
    public class CateringContext:DbContext
    {
        public CateringContext()
            : base("name=CateringConnectionString")
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDish> OrderDishes { get; set; }
        public DbSet<MenuDish> MenuDishes { get; set; }

        public DbSet<Menu> Menus { get; set; }
    }
}
