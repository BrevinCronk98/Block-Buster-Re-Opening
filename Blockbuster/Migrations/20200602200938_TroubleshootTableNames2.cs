using Microsoft.EntityFrameworkCore.Migrations;

namespace Blockbuster.Migrations
{
    public partial class TroubleshootTableNames2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Director_AspNetUsers_UserId",
                table: "Director");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Director_DirectorId",
                table: "DirectorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovie_Movie_MovieId",
                table: "DirectorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_AspNetUsers_UserId",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DirectorMovie",
                table: "DirectorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Director",
                table: "Director");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "DirectorMovie",
                newName: "DirectorMovies");

            migrationBuilder.RenameTable(
                name: "Director",
                newName: "Directors");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_UserId",
                table: "Movies",
                newName: "IX_Movies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DirectorMovie_MovieId",
                table: "DirectorMovies",
                newName: "IX_DirectorMovies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_DirectorMovie_DirectorId",
                table: "DirectorMovies",
                newName: "IX_DirectorMovies_DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Director_UserId",
                table: "Directors",
                newName: "IX_Directors_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DirectorMovies",
                table: "DirectorMovies",
                column: "DirectorMovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovies_Directors_DirectorId",
                table: "DirectorMovies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "DirectorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovies_Movies_MovieId",
                table: "DirectorMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_AspNetUsers_UserId",
                table: "Directors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_AspNetUsers_UserId",
                table: "Movies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovies_Directors_DirectorId",
                table: "DirectorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectorMovies_Movies_MovieId",
                table: "DirectorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_Directors_AspNetUsers_UserId",
                table: "Directors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_AspNetUsers_UserId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DirectorMovies",
                table: "DirectorMovies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Director");

            migrationBuilder.RenameTable(
                name: "DirectorMovies",
                newName: "DirectorMovie");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_UserId",
                table: "Movie",
                newName: "IX_Movie_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Directors_UserId",
                table: "Director",
                newName: "IX_Director_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DirectorMovies_MovieId",
                table: "DirectorMovie",
                newName: "IX_DirectorMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_DirectorMovies_DirectorId",
                table: "DirectorMovie",
                newName: "IX_DirectorMovie_DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Director",
                table: "Director",
                column: "DirectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DirectorMovie",
                table: "DirectorMovie",
                column: "DirectorMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Director_AspNetUsers_UserId",
                table: "Director",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Director_DirectorId",
                table: "DirectorMovie",
                column: "DirectorId",
                principalTable: "Director",
                principalColumn: "DirectorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectorMovie_Movie_MovieId",
                table: "DirectorMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_AspNetUsers_UserId",
                table: "Movie",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
