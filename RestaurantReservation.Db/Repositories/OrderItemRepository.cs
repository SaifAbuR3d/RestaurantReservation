using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public OrderItem CreateOrderItem(OrderItem orderItem)
    {
        _context.OrderItems.Add(orderItem);
        _context.SaveChanges();
        return orderItem;
    }

    public OrderItem UpdateOrderItem(OrderItem orderItem)
    {
        _context.OrderItems.Update(orderItem);
        _context.SaveChanges();
        return orderItem;
    }

    public void DeleteOrderItem(int orderItemId)
    {
        var orderItem = _context.OrderItems.Find(orderItemId);
        if (orderItem != null)
        {
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
        }
    }

    public List<OrderItem> GetOrderItemsByOrder(int orderId)
    {
        return _context.OrderItems
            .Where(oi => oi.OrderId == orderId)
            .ToList();
    }

}