using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Models
{
    public class User
    {
        public enum UserType
        {
            Admin,
            Normal
        }

        public User()
        {
            Dishes=new List<Dish>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }


        public virtual Location Location { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }

    
}
