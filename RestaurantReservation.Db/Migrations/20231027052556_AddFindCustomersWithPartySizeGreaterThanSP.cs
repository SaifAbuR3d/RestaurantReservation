using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFindCustomersWithPartySizeGreaterThanSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var script = @"
                                  CREATE PROCEDURE FindCustomersWithPartySizeGreaterThan
                                   @partySize INT
                                      AS
                                        BEGIN
                                          SELECT DISTINCT C.*
                                          FROM Customers AS C
                                          INNER JOIN Reservations AS R ON C.CustomerId = R.CustomerId
                                          WHERE R.PartySize > @partySize;
                                        END

                          ";
            migrationBuilder.Sql(script);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var command = "DROP PROCEDURE FindCustomersWithPartySizeGreaterThan";
            migrationBuilder.Sql(command);
        }
    }
}