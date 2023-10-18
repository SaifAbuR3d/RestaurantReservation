using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantID { get; set; }
        public int TableID { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public Customer Customer { get; set; }
        public Restaurant Restaurant { get; set; }
        public Table Table { get; set; }
        public List<Order> Orders { get; set; }

    }
}
