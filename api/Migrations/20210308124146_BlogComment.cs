using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class BlogComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "BlogComments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "BlogComments");
        }
    }
}
