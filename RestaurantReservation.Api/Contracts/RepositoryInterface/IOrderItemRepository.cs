using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Contracts.RepositoryInterface;

public interface IOrderItemRepository
{
    void AddOrderItemToOrder(int orderId, OrderItem orderItem);
    void DeleteOrderItem(OrderItem orderItem);
    Task<OrderItem?> GetOrderItemAsync(int reservationId, int orderId, int orderItemId);
    Task<IEnumerable<OrderItem>> GetOrderItemsForOrderAsync(int reservationId, int orderId);
    Task<bool> SaveChangesAsync(int orderId);
}