using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeRestaurantDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var script =
                         @"
                           CREATE VIEW EmployeeRestaurantDetails AS 
                           SELECT 
                           e.EmployeeId, e.FirstName, e.LastName, e.Position, r.RestaurantId, r.Name AS RestaurantName, 
                           r.Address, r.PhoneNumber, r.OpenningHours 
                           FROM Employees e
                           INNER JOIN Restaurants r ON e.RestaurantId = r.RestaurantId
                         ";
            migrationBuilder.Sql(script);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var script = @"DROP VIEW EmployeeRestaurantDetails;";
            migrationBuilder.Sql(script);
        }
    }
}
