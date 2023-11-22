using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories.RepositoryInterface;

public interface IOrderRepository
{
    Task<bool> OrderExistsAsync(int reservationId, int orderId);
    Task<decimal> CalculateTotalAmount(int orderId);
    void CreateOrder(int reservationId, Order order);
    void DeleteOrder(Order order);
    Task<Order?> GetOrderAsync(int reservationId, int orderId);
    Task<IEnumerable<Order>> GetOrdersForReservationAsync(int reservationId);
    Task<bool> SaveChangesAsync();
}