using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class BlogCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BlogPhotos");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "BlogPhotos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPhotos_AppUserId",
                table: "BlogPhotos",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPhotos_AspNetUsers_AppUserId",
                table: "BlogPhotos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPhotos_AspNetUsers_AppUserId",
                table: "BlogPhotos");

            migrationBuilder.DropIndex(
                name: "IX_BlogPhotos_AppUserId",
                table: "BlogPhotos");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BlogPhotos");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "BlogPhotos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
