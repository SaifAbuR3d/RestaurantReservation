using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public Order? CreateOrder(int reservationId, Order order)
    {
        var reservation = _context.Reservations
            .Include(r => r.Orders)
            .FirstOrDefault(r => r.ReservationID == reservationId);

        if (reservation == null)
        {
            return null;
        }

        _context.Orders.Add(order);
        reservation.Orders.Add(order);

        _context.SaveChanges();

        return order;
    }

    public Order UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
        _context.SaveChanges();
        return order;
    }

    public void DeleteOrder(int orderId)
    {
        var order = _context.Orders.Find(orderId);
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}