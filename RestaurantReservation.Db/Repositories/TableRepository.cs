using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Repositories.RepositoryInterface;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository : ITableRepository
{
    private readonly RestaurantReservationDbContext _context;

    public TableRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> TableExistsAsync(int restaurantId, int id)
    {
        return await _context.Tables
            .AnyAsync(c => c.RestaurantId == restaurantId
                        && c.TableId == id);
    }

    public async Task<IEnumerable<Table>> GetTablesInRestaurantAsync(int restaurantId)
    {
        return await _context.Tables.Where(t => t.RestaurantId == restaurantId).ToListAsync();
    }

    public async Task<Table?> GetTableAsync(int restaurantId, int tableId)
    {
        return await _context.Tables.FirstOrDefaultAsync(t => t.RestaurantId == restaurantId
                                                           && t.TableId == tableId);
    }

    public Table CreateTable(int restaurantId, Table table)
    {
        _context.Tables.Add(table);
        table.RestaurantId = restaurantId;

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