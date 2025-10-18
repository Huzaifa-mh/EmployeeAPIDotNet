using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeAPICURD.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeCode", "EmployeeAge", "EmployeeDepartment", "EmployeeName" },
                values: new object[,]
                {
                    { 1001, 21, "Software", "Huzaifa" },
                    { 1002, 21, "HR", "Muhammad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeCode",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeCode",
                keyValue: 1002);
        }
    }
}
