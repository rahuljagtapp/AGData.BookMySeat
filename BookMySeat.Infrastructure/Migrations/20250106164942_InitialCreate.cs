using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGData.BookMySeat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

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

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    VisitorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostEmployee = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HostEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                    table.ForeignKey(
                        name: "FK_Visitors_Employees_HostEmployeeId",
                        column: x => x.HostEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingRecords",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRecords", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingRecords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRecords_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRecords_EmployeeId",
                table: "BookingRecords",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRecords_ResourceId",
                table: "BookingRecords",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_HostEmployeeId",
                table: "Visitors",
                column: "HostEmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRecords");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
