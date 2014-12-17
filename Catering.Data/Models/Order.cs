using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Models
{
    public class Order
    {
        public Order()
        {
            OrderDishes=new List<OrderDish>();
        }
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDish> OrderDishes { get; set; }

    }
}
