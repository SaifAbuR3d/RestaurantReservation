using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ReservationID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Reservation Reservation { get; set; }
        public Employee Employee { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
