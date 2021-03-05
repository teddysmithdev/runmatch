using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EventAttendee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Clubs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventAttendees",
                columns: table => new
                {
                    AppUserId = table.Column<string>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    EventId1 = table.Column<int>(nullable: false),
                    IsHost = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttendees", x => new { x.AppUserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventAttendees_AspNetUsers_EventId",
                        column: x => x.EventId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventAttendees_Events_EventId1",
                        column: x => x.EventId1,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendees_EventId",
                table: "EventAttendees",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendees_EventId1",
                table: "EventAttendees",
                column: "EventId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventAttendees");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Clubs");
        }
    }
}
