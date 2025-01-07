using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGData.BookMySeat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updtedseat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRecords_Resources_ResourceId",
                table: "BookingRecords");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.RenameColumn(
                name: "ResourceId",
                table: "BookingRecords",
                newName: "SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingRecords_ResourceId",
                table: "BookingRecords",
                newName: "IX_BookingRecords_SeatId");

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    SeatName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRecords_Seats_SeatId",
                table: "BookingRecords",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRecords_Seats_SeatId",
                table: "BookingRecords");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "BookingRecords",
                newName: "ResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingRecords_SeatId",
                table: "BookingRecords",
                newName: "IX_BookingRecords_ResourceId");

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ResourceCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResourceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRecords_Resources_ResourceId",
                table: "BookingRecords",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "ResourceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
