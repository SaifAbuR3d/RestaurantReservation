using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddCalculateRevenueDatabaseFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var script = @"CREATE FUNCTION CalculateTotalRevenue(@restaurantId INT)
                            RETURNS DECIMAL(18, 2)
                            AS
                                BEGIN
                                DECLARE @totalRevenue DECIMAL(18, 2);

                                SELECT @totalRevenue = SUM(o.TotalAmount)
                                FROM Orders o
                                INNER JOIN Reservations r ON o.ReservationID = r.ReservationID
                                WHERE r.RestaurantID = @restaurantId;

                                RETURN ISNULL(@totalRevenue, 0);
                            END;
                           ";
            migrationBuilder.Sql(script);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var script = @"DROP FUNCTION CalculateTotalRevenue"; 
            migrationBuilder.Sql(script);
        }
    }
}
