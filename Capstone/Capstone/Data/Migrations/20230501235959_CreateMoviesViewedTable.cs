using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateMoviesViewedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Creating Table
            migrationBuilder.CreateTable(
                name: "movies_viewed",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    ViewingID = table.Column<int>(nullable: false),
                    Movie = table.Column<string>(maxLength: 100, nullable: true),
                },

                constraints: table =>
                {
                    //set primary_key
                    table.PrimaryKey("PK_movies_viewed", x => x.ID);

                    //set foreign_key
                    table.ForeignKey(
                        name: "FK_movies_viewed_viewed_ViewingID",
                        column: x => x.ViewingID,
                        principalTable: "Viewings",
                        principalColumn: "ViewingID",
                        onDelete: ReferentialAction.Cascade);
                }
                );

            //Index
            migrationBuilder.CreateIndex(
                name: "IX_movies_viewed_ViewingID",
                table: "movies_viewed",
                column: "ViewingID");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies_viewed");
        }
    }
}
