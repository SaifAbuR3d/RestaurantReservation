using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public interface IMenuItemRepository
    {
        MenuItem CreateMenuItem(int restaurantId, MenuItem menuItem);
        void DeleteMenuItem(MenuItem menuItem);
        Task<MenuItem?> GetMenuItemAsync(int restaurantId, int menuItemId);
        Task<IEnumerable<MenuItem>> GetMenuItemsInRestaurantAsync(int restaurantId);
        Task<bool> MenuItemExistsAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}