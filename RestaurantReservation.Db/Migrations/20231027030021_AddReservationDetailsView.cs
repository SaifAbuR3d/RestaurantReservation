using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var script =
               @" CREATE VIEW ReservationDetails AS
                  SELECT
                    r.ReservationID,
                    c.CustomerID,
                    c.FirstName AS CustomerFirstName,
                    c.LastName AS CustomerLastName,
                    r.ReservationDate,
                    r.PartySize,
                    r.RestaurantID,
                    res.Name AS RestaurantName,
                    res.Address AS RestaurantAddress
                FROM Reservations r
                INNER JOIN Customers c ON r.CustomerID = c.CustomerID
                INNER JOIN Restaurants res ON r.RestaurantID = res.RestaurantID;
                ";
            migrationBuilder.Sql(script);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var script = @"DROP VIEW ReservationDetails;";
            migrationBuilder.Sql(script);
        }
    }
}
