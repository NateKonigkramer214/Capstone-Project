using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Data.Migrations
{
    /// <inheritdoc />
    public partial class Bookings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_IdentityUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_IdentityUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_IdentityUserId",
                table: "Bookings",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_IdentityUserId",
                table: "Bookings",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
