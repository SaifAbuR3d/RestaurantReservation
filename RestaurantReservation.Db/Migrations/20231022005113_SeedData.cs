using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "jane@example.com", "Jane", "Smith", "987-654-3210" },
                    { 3, "michael@example.com", "Michael", "Johnson", "555-555-5555" },
                    { 4, "emily@example.com", "Emily", "Williams", "111-222-3333" },
                    { 5, "william@example.com", "William", "Brown", "444-444-4444" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "OpenningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St.", "Mr Italian", "9:00 AM - 10:00 PM", "555-123-4567" },
                    { 2, "456 Manara St.", "Meat Haven", "10:00 AM - 9:00 PM", "555-987-6543" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "RestaurantId", "position" },
                values: new object[,]
                {
                    { 1, "Alice", "Johnson", 1, "Manager" },
                    { 2, "Bob", "Smith", 2, "Manager" },
                    { 3, "Charlie", "Williams", 1, "Waiter" },
                    { 4, "David", "Brown", 2, "Chef" },
                    { 5, "Eva", "Davis", 1, "Chef" },
                    { 6, "John", "Davis", 2, "Waiter" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Classic Italian pasta dish", "Spaghetti Bolognese", 12.99m, 1 },
                    { 2, "Freshly grilled salmon with lemon butter sauce", "Grilled Salmon", 17.99m, 2 },
                    { 3, "Traditional Italian pizza with tomatoes and fresh mozzarella", "Margherita Pizza", 10.99m, 1 },
                    { 4, "Juicy beef steak cooked to perfection", "Beef Steak", 19.99m, 2 },
                    { 5, "Crisp romaine lettuce, croutons, and Caesar dressing", "Caesar Salad", 8.99m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantID" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 2 },
                    { 3, 6, 1 },
                    { 4, 4, 2 },
                    { 5, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationID", "CustomerId", "PartySize", "ReservationDate", "RestaurantID", "TableID" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2023, 10, 22, 4, 51, 13, 464, DateTimeKind.Local).AddTicks(1787), 1, 1 },
                    { 2, 2, 2, new DateTime(2023, 10, 22, 4, 51, 13, 464, DateTimeKind.Local).AddTicks(1791), 2, 2 },
                    { 3, 3, 6, new DateTime(2023, 10, 22, 6, 51, 13, 464, DateTimeKind.Local).AddTicks(1794), 1, 3 },
                    { 4, 1, 1, new DateTime(2023, 10, 22, 7, 51, 13, 464, DateTimeKind.Local).AddTicks(1796), 2, 2 },
                    { 5, 2, 4, new DateTime(2023, 10, 22, 5, 51, 13, 464, DateTimeKind.Local).AddTicks(1798), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "EmployeeID", "OrderDate", "ReservationID", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2023, 10, 22, 3, 51, 13, 464, DateTimeKind.Local).AddTicks(1682), 1, 36.97m },
                    { 2, 5, new DateTime(2023, 10, 22, 3, 51, 13, 464, DateTimeKind.Local).AddTicks(1726), 1, 39.93m },
                    { 3, 4, new DateTime(2023, 10, 22, 3, 51, 13, 464, DateTimeKind.Local).AddTicks(1729), 2, 37.98m },
                    { 4, 4, new DateTime(2023, 10, 22, 3, 51, 13, 464, DateTimeKind.Local).AddTicks(1731), 2, 17.99m },
                    { 5, 5, new DateTime(2023, 10, 22, 3, 51, 13, 464, DateTimeKind.Local).AddTicks(1733), 3, 12.99m },
                    { 6, 4, new DateTime(2023, 10, 22, 3, 51, 13, 464, DateTimeKind.Local).AddTicks(1736), 4, 35.98m },
                    { 7, 5, new DateTime(2023, 10, 22, 3, 51, 13, 464, DateTimeKind.Local).AddTicks(1738), 5, 8.99m },
                    { 8, 5, new DateTime(2023, 10, 22, 3, 51, 13, 464, DateTimeKind.Local).AddTicks(1740), 5, 8.99m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "MenuItemID", "OrderID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 3, 1, 1 },
                    { 3, 5, 2, 3 },
                    { 4, 1, 2, 1 },
                    { 5, 2, 3, 1 },
                    { 6, 4, 3, 1 },
                    { 7, 2, 4, 1 },
                    { 8, 1, 5, 1 },
                    { 9, 2, 6, 2 },
                    { 10, 5, 7, 1 },
                    { 11, 5, 8, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);
        }
    }
}
