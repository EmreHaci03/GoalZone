using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalZone.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Teams_TeamId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_TeamId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "News");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_TeamId",
                table: "News",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Teams_TeamId",
                table: "News",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }
    }
}
