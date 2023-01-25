using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEfCore.Migrations
{
    public partial class addValueInAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Credentials",
                keyColumn: "credentialId",
                keyValue: 1,
                columns: new[] { "hashed", "salted" },
                values: new object[] { "tRpuHyCTQXB0qHHBjdy31uHfUpPDMEXMW73NmH7wQ1I=", new byte[] { 31, 98, 216, 245, 120, 65, 245, 24, 52, 167, 115, 222, 47, 36, 137, 13 } });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "employeeId",
                keyValue: 1,
                columns: new[] { "birthday", "firstname", "gender", "lastname" },
                values: new object[] { new DateTime(2023, 1, 25, 11, 21, 40, 426, DateTimeKind.Local).AddTicks(8129), "admin", "male", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Credentials",
                keyColumn: "credentialId",
                keyValue: 1,
                columns: new[] { "hashed", "salted" },
                values: new object[] { "gknDqk2aJJKG+WGZaQhYUsuSxgIwXclcwHFK5wT9Tzc=", new byte[] { 106, 154, 69, 253, 78, 81, 51, 181, 151, 105, 133, 128, 196, 176, 50, 69 } });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "employeeId",
                keyValue: 1,
                columns: new[] { "birthday", "firstname", "gender", "lastname" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null });
        }
    }
}
