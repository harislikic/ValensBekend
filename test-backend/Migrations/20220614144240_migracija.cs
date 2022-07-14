using Microsoft.EntityFrameworkCore.Migrations;

namespace test_backend.Migrations
{
    public partial class migracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Account_UserId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieGenre_MovieGenreId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieGenreId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_UserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieGenreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Movies");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieGenre_id",
                table: "Movies",
                column: "MovieGenre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_User_id",
                table: "Movies",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Account_User_id",
                table: "Movies",
                column: "User_id",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieGenre_MovieGenre_id",
                table: "Movies",
                column: "MovieGenre_id",
                principalTable: "MovieGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Account_User_id",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieGenre_MovieGenre_id",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieGenre_id",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_User_id",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "MovieGenreId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieGenreId",
                table: "Movies",
                column: "MovieGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Account_UserId",
                table: "Movies",
                column: "UserId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieGenre_MovieGenreId",
                table: "Movies",
                column: "MovieGenreId",
                principalTable: "MovieGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
