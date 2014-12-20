using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Data.Repositories.Dish
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public string FormattedDate { get; set; }
        public List<DishDTO> Dishes { get; set; }
    }
}
