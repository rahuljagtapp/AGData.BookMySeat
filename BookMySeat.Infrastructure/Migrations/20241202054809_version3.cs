using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGData.BookMySeat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class version3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HostEmployee",
                table: "Visitors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceName",
                table: "Resources",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceCategorey",
                table: "Resources",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeRole",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_HostEmployeeId",
                table: "Visitors",
                column: "HostEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRecords_EmployeeId",
                table: "BookingRecords",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRecords_ResourceId",
                table: "BookingRecords",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRecords_Employees_EmployeeId",
                table: "BookingRecords",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRecords_Resources_ResourceId",
                table: "BookingRecords",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "ResourceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Employees_HostEmployeeId",
                table: "Visitors",
                column: "HostEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRecords_Employees_EmployeeId",
                table: "BookingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingRecords_Resources_ResourceId",
                table: "BookingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Employees_HostEmployeeId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_HostEmployeeId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_BookingRecords_EmployeeId",
                table: "BookingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BookingRecords_ResourceId",
                table: "BookingRecords");

            migrationBuilder.AlterColumn<string>(
                name: "HostEmployee",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ResourceName",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ResourceCategorey",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeRole",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
