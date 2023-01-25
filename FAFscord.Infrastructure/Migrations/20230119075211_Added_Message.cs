using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAFscord.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_ChatStudents_UserId_ChatId",
                        columns: x => new { x.UserId, x.ChatId },
                        principalTable: "ChatStudents",
                        principalColumns: new[] { "UserId", "ChatId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatStudents_ChatRoleId",
                table: "ChatStudents",
                column: "ChatRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId_ChatId",
                table: "Messages",
                columns: new[] { "UserId", "ChatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatStudents_ChatRoles_ChatRoleId",
                table: "ChatStudents",
                column: "ChatRoleId",
                principalTable: "ChatRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatStudents_ChatRoles_ChatRoleId",
                table: "ChatStudents");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_ChatStudents_ChatRoleId",
                table: "ChatStudents");
        }
    }
}
