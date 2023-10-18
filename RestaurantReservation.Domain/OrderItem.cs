using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderID { get; set; }
        public int MenuItemID { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
