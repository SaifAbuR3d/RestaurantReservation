using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain;

namespace RestaurantReservation.Db
{
    public class ReservationsRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationsRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public Reservation? GetReservation(int reservationId)
        {
            var reservation = _context.Reservations
                .Include(r => r.Customer)
                .Include(r => r.Table)
                .Include(r => r.Restaurant)
                .Include(r => r.Orders)
                .FirstOrDefault(r => r.ReservationID == reservationId);

            return reservation;
        }

        public List<Reservation> GetReservationsByCustomer(int customerId)
        {
            return _context.Reservations
                .Where(r => r.CustomerId == customerId)
                .ToList();
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public Reservation? UpdateReservationDetails(int reservationId, DateTime newDate, int newPartySize)
        {
            var reservation = _context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                reservation.ReservationDate = newDate;
                reservation.PartySize = newPartySize;
                _context.SaveChanges();
            }
            return reservation;
        }

        public void DeleteReservation(int reservationId)
        {
            var reservation = _context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

        public void ListOrdersAndMenuItems(int reservationId)
        {
            var reservation = _context.Reservations
                       .Include(r => r.Orders)
                       .ThenInclude(o => o.OrderItems)
                       .ThenInclude(oi => oi.MenuItem)
                       .FirstOrDefault(r => r.ReservationID == reservationId);

            if (reservation == null)
            {
                return; 
            }

            foreach (var order in reservation.Orders)
            {
                Console.WriteLine(order.OrderID);
                foreach(var orderItem in order.OrderItems)
                {
                    Console.WriteLine($" - {orderItem.MenuItem.MenuItemId}");
                }
            }
        }

    }
}