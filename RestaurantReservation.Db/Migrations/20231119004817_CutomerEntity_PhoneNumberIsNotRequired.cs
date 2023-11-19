using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CutomerEntity_PhoneNumberIsNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 6,
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 7,
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 8,
                column: "OrderDate",
                value: new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 10, 27, 9, 25, 55, 926, DateTimeKind.Local).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 10, 27, 9, 25, 55, 926, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 10, 27, 11, 25, 55, 926, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 10, 27, 12, 25, 55, 926, DateTimeKind.Local).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationID",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 10, 27, 10, 25, 55, 926, DateTimeKind.Local).AddTicks(4404));
        }
    }
}
