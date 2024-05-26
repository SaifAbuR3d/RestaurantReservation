using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories.RepositoryInterface;

public interface IMenuItemRepository
{
    MenuItem CreateMenuItem(int restaurantId, MenuItem menuItem);
    void DeleteMenuItem(MenuItem menuItem);
    Task<MenuItem?> GetMenuItemAsync(int restaurantId, int menuItemId);
    Task<IEnumerable<MenuItem>> GetMenuItemsInRestaurantAsync(int restaurantId);
    Task<IEnumerable<MenuItem>> GetOrderedMenuItemsByReservationIdAsync(int reservationId);
    Task<bool> MenuItemExistsAsync(int id);
    Task<bool> SaveChangesAsync();
}