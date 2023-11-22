using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class FixedDateForSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2020, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2020, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 8,
                column: "OrderDate",
                value: new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2020, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2020, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 19, 2, 48, 16, 797, DateTimeKind.Local).AddTicks(346));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 19, 2, 48, 16, 797, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 19, 2, 48, 16, 797, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 19, 2, 48, 16, 797, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 19, 2, 48, 16, 797, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 11, 19, 2, 48, 16, 797, DateTimeKind.Local).AddTicks(420));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2023, 11, 19, 2, 48, 16, 797, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 8,
                column: "OrderDate",
                value: new DateTime(2023, 11, 19, 2, 48, 16, 797, DateTimeKind.Local).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 19, 3, 48, 16, 797, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 19, 3, 48, 16, 797, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 19, 5, 48, 16, 797, DateTimeKind.Local).AddTicks(540));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 19, 6, 48, 16, 797, DateTimeKind.Local).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 19, 4, 48, 16, 797, DateTimeKind.Local).AddTicks(545));
        }
    }
}
