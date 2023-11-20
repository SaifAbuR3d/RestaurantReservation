using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public interface ITableRepository
    {
        Table CreateTable(int restaurantId, Table table);
        void DeleteTable(Table table);
        Task<Table?> GetTableAsync(int restaurantId, int tableId);
        Task<IEnumerable<Table>> GetTablesInRestaurantAsync(int restaurantId);
        Task<bool> SaveChangesAsync();
        Task<bool> TableExistsAsync(int id);
    }
}