using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FAFscord.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ChatStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "ChatRoles",
                columns: new[] { "Id", "Role" },
                values: new object[,]
                {
                    { new Guid("c5627232-b455-4d6c-9b6e-ba14b6589fd9"), "Admin" },
                    { new Guid("fbad6e22-61c9-4772-a379-5462ff42496e"), "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5627232-b455-4d6c-9b6e-ba14b6589fd9"));

            migrationBuilder.DeleteData(
                table: "ChatRoles",
                keyColumn: "Id",
                keyValue: new Guid("fbad6e22-61c9-4772-a379-5462ff42496e"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ChatStudents");
        }
    }
}
