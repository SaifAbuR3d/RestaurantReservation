using RestaurantReservation.Domain;

namespace RestaurantReservation.Db
{
    public class TableRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public Table CreateTable(Table table)
        {
            _context.Tables.Add(table);
            _context.SaveChanges();
            return table;
        }

        public Table UpdateTable(Table table)
        {
            _context.Tables.Update(table);
            _context.SaveChanges();
            return table;
        }

        public Table? UpdateTableDetails(int tableId, int capacity)
        {
            var table = _context.Tables.Find(tableId);
            if (table != null)
            {
                table.Capacity = capacity;
                _context.SaveChanges();
            }
            return table;
        }

        public void DeleteTable(int tableId)
        {
            var table = _context.Tables.Find(tableId);
            if (table != null)
            {
                _context.Tables.Remove(table);
                _context.SaveChanges();
            }
        }
    }
}