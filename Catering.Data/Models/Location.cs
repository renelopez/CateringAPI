using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Models
{
    public class Location
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual User User { get; set; }
    }
}
