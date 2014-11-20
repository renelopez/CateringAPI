using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Models
{
    public class UserDish
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Dish Dish { get; set; }
        public DateTime DateTime { get; set; }  
    }
}
