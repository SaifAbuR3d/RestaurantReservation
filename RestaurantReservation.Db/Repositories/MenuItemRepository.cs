using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public MenuItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> MenuItemExistsAsync(int id)
    {
        return await _context.MenuItems.AnyAsync(m => m.MenuItemId == id);
    }

    public async Task<IEnumerable<MenuItem>> GetMenuItemsInRestaurantAsync(int restaurantId)
    {
        return await _context.MenuItems.Where(m => m.RestaurantId == restaurantId).ToListAsync();
    }

    public async Task<MenuItem?> GetMenuItemAsync(int restaurantId, int menuItemId)
    {
        return await _context.MenuItems
            .FirstOrDefaultAsync(m => m.RestaurantId == restaurantId
                                   && m.MenuItemId == menuItemId);
    }

    public MenuItem CreateMenuItem(int restaurantId, MenuItem menuItem)
    {
        _context.MenuItems.Add(menuItem);
        menuItem.RestaurantId = restaurantId;

        return menuItem;
    }

    public void DeleteMenuItem(MenuItem menuItem)
    {
        _context.MenuItems.Remove(menuItem);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}
