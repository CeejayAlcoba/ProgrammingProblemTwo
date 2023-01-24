using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEfCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    credentialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salted = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    hashed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.credentialId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    positionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.positionId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    positionId = table.Column<int>(type: "int", nullable: false),
                    credentialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Credentials_credentialId",
                        column: x => x.credentialId,
                        principalTable: "Credentials",
                        principalColumn: "credentialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_positionId",
                        column: x => x.positionId,
                        principalTable: "Positions",
                        principalColumn: "positionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "credentialId", "hashed", "salted", "username" },
                values: new object[] { 1, "gknDqk2aJJKG+WGZaQhYUsuSxgIwXclcwHFK5wT9Tzc=", new byte[] { 106, 154, 69, 253, 78, 81, 51, 181, 151, 105, 133, 128, 196, 176, 50, 69 }, "admin" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "positionId", "type" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Manager" },
                    { 3, "Supervisor" },
                    { 4, "Staff" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "employeeId", "birthday", "credentialId", "firstname", "gender", "lastname", "positionId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_credentialId",
                table: "Employees",
                column: "credentialId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_positionId",
                table: "Employees",
                column: "positionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
