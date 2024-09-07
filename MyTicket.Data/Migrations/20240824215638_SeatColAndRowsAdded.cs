using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTicket.Data.Migrations
{
    public partial class SeatColAndRowsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Column",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeatNumber",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Column",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Seats");
        }
    }
}
