using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public MenuItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public MenuItem CreateMenuItem(MenuItem menuItem)
    {
        _context.MenuItems.Add(menuItem);
        _context.SaveChanges();
        return menuItem;
    }

    public MenuItem UpdateMenuItem(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
        _context.SaveChanges();
        return menuItem;
    }

    public void DeleteMenuItem(int menuItemId)
    {
        var menuItem = _context.MenuItems.Find(menuItemId);
        if (menuItem != null)
        {
            _context.MenuItems.Remove(menuItem);
            _context.SaveChanges();
        }
    }

    public List<MenuItem> ListOrderedMenuItems(int reservationId)
    {
        var reservation = _context.Reservations
            .Include(r => r.Orders)
            .ThenInclude(o => o.OrderItems)
            .ThenInclude(oi => oi.MenuItem)
            .FirstOrDefault(r => r.ReservationID == reservationId);

        if (reservation == null)
        {
            return new List<MenuItem>();
        }

        var orderedMenuItems = reservation.Orders
            .SelectMany(o => o.OrderItems.Select(oi => oi.MenuItem))
            .Distinct()
            .ToList();

        return orderedMenuItems;
    }

}