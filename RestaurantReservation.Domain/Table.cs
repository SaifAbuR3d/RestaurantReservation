using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain
{
    public class Table
    {
        public int TableId { get; set; }
        public int RestaurantID { get; set; }
        public int Capacity { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
