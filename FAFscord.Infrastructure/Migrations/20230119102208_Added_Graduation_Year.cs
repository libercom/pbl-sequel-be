using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAFscord.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedGraduationYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GraduationDate",
                table: "AcademicGroups");

            migrationBuilder.AddColumn<int>(
                name: "GraduationYear",
                table: "AcademicGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GraduationYear",
                table: "AcademicGroups");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "GraduationDate",
                table: "AcademicGroups",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
