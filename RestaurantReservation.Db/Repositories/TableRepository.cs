using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository : ITableRepository
{
    private readonly RestaurantReservationDbContext _context;

    public TableRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> TableExistsAsync(int id)
    {
        return await _context.Tables.AnyAsync(c => c.TableId == id);
    }

    public async Task<IEnumerable<Table>> GetTablesInRestaurantAsync(int restaurantId)
    {
        return await _context.Tables.Where(t => t.RestaurantID == restaurantId).ToListAsync();
    }

    public async Task<Table?> GetTableAsync(int restaurantId, int tableId)
    {
        return await _context.Tables.FirstOrDefaultAsync(t => t.RestaurantID == restaurantId
                                                           && t.TableId == tableId);
    }

    public Table CreateTable(int restaurantId, Table table)
    {
        _context.Tables.Add(table);
        table.RestaurantID = restaurantId;

        return table;
    }

    public void DeleteTable(Table table)
    {
        _context.Tables.Remove(table);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}