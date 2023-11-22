using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> OrderExistsAsync(int reservationId, int orderId)
    {
        return await _context.Orders.AnyAsync(c => c.ReservationId == reservationId && c.OrderId == orderId);
    }

    public async Task<IEnumerable<Order>> GetOrdersForReservationAsync(int reservationId)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(o => o.MenuItem)
            .Where(o => o.ReservationId == reservationId)
            .ToListAsync();

    }

    public async Task<Order?> GetOrderAsync(int reservationId, int orderId)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.ReservationId == reservationId && o.OrderId == orderId);
    }

    public void CreateOrder(int reservationId, Order order)
    {
        order.ReservationId = reservationId;
        _context.Orders.Add(order);
    }

    public void DeleteOrder(Order order)
    {
        _context.Orders.Remove(order);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }

    public async Task<decimal> CalculateTotalAmount(int orderId)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.MenuItem)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);

        if (order == null)
        {
            return 0;
        }

        decimal totalAmount = order.OrderItems?.Sum(oi => oi.Quantity * oi.MenuItem.Price) ?? 0;
        order.TotalAmount = totalAmount;

        return totalAmount;
    }
}
