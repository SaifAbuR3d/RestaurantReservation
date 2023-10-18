using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Domain
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OpenningHours { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Table> Tables { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
