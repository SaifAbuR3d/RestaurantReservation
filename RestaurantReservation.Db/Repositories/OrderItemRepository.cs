using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Repositories.RepositoryInterface;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly RestaurantReservationDbContext _context;
    private readonly IOrderRepository _orderRepository;

    public OrderItemRepository(RestaurantReservationDbContext context,
        IOrderRepository orderRepository)
    {
        _context = context;
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemsForOrderAsync(int reservationId, int orderId)
    {
        return await _context.OrderItems
            .Include(oi => oi.MenuItem)
            .Where(oi => oi.Order.ReservationId == reservationId && oi.OrderId == orderId)
            .ToListAsync();
    }

    public async Task<OrderItem?> GetOrderItemAsync(int reservationId, int orderId, int orderItemId)
    {
        return await _context.OrderItems
                         .Include(oi => oi.MenuItem)
                         .FirstOrDefaultAsync(oi =>
                                              oi.Order.ReservationId == reservationId &&
                                              oi.OrderId == orderId &&
                                              oi.OrderItemId == orderItemId);
    }

    public void AddOrderItemToOrder(int orderId, OrderItem orderItem)
    {
        orderItem.OrderId = orderId;
        _context.OrderItems.Add(orderItem);
    }

    public void DeleteOrderItem(OrderItem orderItem)
    {
        _context.OrderItems.Remove(orderItem);
    }

    public async Task<bool> SaveChangesAsync(int orderId)
    {
        var order = _context.Orders.Find(orderId);
        if (order != null)
        {
            order.TotalAmount = await _orderRepository.CalculateTotalAmount(orderId);
        }
        return (await _context.SaveChangesAsync() >= 0);
    }
}
