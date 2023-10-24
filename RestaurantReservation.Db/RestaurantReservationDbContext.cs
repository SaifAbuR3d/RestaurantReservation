using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Domain;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }

        public RestaurantReservationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureNoCascadeDelete(modelBuilder);

            SeedData(modelBuilder);
        }

        private void ConfigureNoCascadeDelete(ModelBuilder modelBuilder)
        {
            var cascadeDeleteFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var FK in cascadeDeleteFKs)
                FK.DeleteBehavior = DeleteBehavior.NoAction;
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            SeedCustomers(modelBuilder);
            SeedEmployees(modelBuilder);
            SeedMenuItems(modelBuilder);
            SeedOrders(modelBuilder);
            SeedOrderItems(modelBuilder);
            SeedReservations(modelBuilder);
            SeedRestaurants(modelBuilder);
            SeedTables(modelBuilder);
        }

        private void SeedCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", PhoneNumber = "123-456-7890" },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", PhoneNumber = "987-654-3210" },
                new Customer { Id = 3, FirstName = "Michael", LastName = "Johnson", Email = "michael@example.com", PhoneNumber = "555-555-5555" },
                new Customer { Id = 4, FirstName = "Emily", LastName = "Williams", Email = "emily@example.com", PhoneNumber = "111-222-3333" },
                new Customer { Id = 5, FirstName = "William", LastName = "Brown", Email = "william@example.com", PhoneNumber = "444-444-4444" }
            );
        }

        private void SeedEmployees(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "Alice", LastName = "Johnson", position = "Manager" },
                new Employee { EmployeeId = 2, RestaurantId = 2, FirstName = "Bob", LastName = "Smith", position = "Manager" },
                new Employee { EmployeeId = 3, RestaurantId = 1, FirstName = "Charlie", LastName = "Williams", position = "Waiter" },
                new Employee { EmployeeId = 4, RestaurantId = 2, FirstName = "David", LastName = "Brown", position = "Chef" },
                new Employee { EmployeeId = 5, RestaurantId = 1, FirstName = "Eva", LastName = "Davis", position = "Chef" },
                new Employee { EmployeeId = 6, RestaurantId = 2, FirstName = "John", LastName = "Davis", position = "Waiter" }

            );
        }

        private void SeedMenuItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { MenuItemId = 1, RestaurantId = 1, Name = "Spaghetti Bolognese", Description = "Classic Italian pasta dish", Price = 12.99m },
                new MenuItem { MenuItemId = 2, RestaurantId = 2, Name = "Grilled Salmon", Description = "Freshly grilled salmon with lemon butter sauce", Price = 17.99m },
                new MenuItem { MenuItemId = 3, RestaurantId = 1, Name = "Margherita Pizza", Description = "Traditional Italian pizza with tomatoes and fresh mozzarella", Price = 10.99m },
                new MenuItem { MenuItemId = 4, RestaurantId = 2, Name = "Beef Steak", Description = "Juicy beef steak cooked to perfection", Price = 19.99m },
                new MenuItem { MenuItemId = 5, RestaurantId = 1, Name = "Caesar Salad", Description = "Crisp romaine lettuce, croutons, and Caesar dressing", Price = 8.99m }
            );
        }

        private void SeedOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderID = 1, ReservationID = 1, EmployeeID = 5, OrderDate = DateTime.Now, TotalAmount = 36.97m },
                new Order { OrderID = 2, ReservationID = 1, EmployeeID = 5, OrderDate = DateTime.Now, TotalAmount = 39.93m },
                new Order { OrderID = 3, ReservationID = 2, EmployeeID = 4, OrderDate = DateTime.Now, TotalAmount = 37.98m },
                new Order { OrderID = 4, ReservationID = 2, EmployeeID = 4, OrderDate = DateTime.Now, TotalAmount = 17.99m },
                new Order { OrderID = 5, ReservationID = 3, EmployeeID = 5, OrderDate = DateTime.Now, TotalAmount = 12.99m },
                new Order { OrderID = 6, ReservationID = 4, EmployeeID = 4, OrderDate = DateTime.Now, TotalAmount = 35.98m },
                new Order { OrderID = 7, ReservationID = 5, EmployeeID = 5, OrderDate = DateTime.Now, TotalAmount = 8.99m },
                new Order { OrderID = 8, ReservationID = 5, EmployeeID = 5, OrderDate = DateTime.Now, TotalAmount = 8.99m }
            );
        }

        private void SeedOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderID = 1, MenuItemID = 1, Quantity = 2 },
                new OrderItem { OrderItemId = 2, OrderID = 1, MenuItemID = 3, Quantity = 1 },
                new OrderItem { OrderItemId = 3, OrderID = 2, MenuItemID = 5, Quantity = 3 },
                new OrderItem { OrderItemId = 4, OrderID = 2, MenuItemID = 1, Quantity = 1 },
                new OrderItem { OrderItemId = 5, OrderID = 3, MenuItemID = 2, Quantity = 1 },
                new OrderItem { OrderItemId = 6, OrderID = 3, MenuItemID = 4, Quantity = 1 },
                new OrderItem { OrderItemId = 7, OrderID = 4, MenuItemID = 2, Quantity = 1 },
                new OrderItem { OrderItemId = 8, OrderID = 5, MenuItemID = 1, Quantity = 1 },
                new OrderItem { OrderItemId = 9, OrderID = 6, MenuItemID = 2, Quantity = 2 },
                new OrderItem { OrderItemId = 10, OrderID = 7, MenuItemID = 5, Quantity = 1 },
                new OrderItem { OrderItemId = 11, OrderID = 8, MenuItemID = 5, Quantity = 1 }
            );
        }

        private void SeedReservations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationID = 1, CustomerId = 1, RestaurantID = 1, TableID = 1, ReservationDate = DateTime.Now.AddHours(1), PartySize = 4 },
                new Reservation { ReservationID = 2, CustomerId = 2, RestaurantID = 2, TableID = 2, ReservationDate = DateTime.Now.AddHours(1), PartySize = 2 },
                new Reservation { ReservationID = 3, CustomerId = 3, RestaurantID = 1, TableID = 3, ReservationDate = DateTime.Now.AddHours(3), PartySize = 6 },
                new Reservation { ReservationID = 4, CustomerId = 1, RestaurantID = 2, TableID = 2, ReservationDate = DateTime.Now.AddHours(4), PartySize = 1 },
                new Reservation { ReservationID = 5, CustomerId = 2, RestaurantID = 1, TableID = 5, ReservationDate = DateTime.Now.AddHours(2), PartySize = 4 }
            );
        }

        private void SeedRestaurants(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { RestaurantId = 1, Name = "Mr Italian", Address = "123 Main St.", PhoneNumber = "555-123-4567", OpenningHours = "9:00 AM - 10:00 PM" },
                new Restaurant { RestaurantId = 2, Name = "Meat Haven", Address = "456 Manara St.", PhoneNumber = "555-987-6543", OpenningHours = "10:00 AM - 9:00 PM" }
            );
        }

        private void SeedTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, RestaurantID = 1, Capacity = 4 },
                new Table { TableId = 2, RestaurantID = 2, Capacity = 2 },
                new Table { TableId = 3, RestaurantID = 1, Capacity = 6 },
                new Table { TableId = 4, RestaurantID = 2, Capacity = 4 },
                new Table { TableId = 5, RestaurantID = 1, Capacity = 5 }
            );
        }

    }
}