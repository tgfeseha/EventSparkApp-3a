using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "event_date_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_location_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_types_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EventDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Date = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventIds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Fee = table.Column<decimal>(nullable: false),
                    PictureURL = table.Column<string>(nullable: true),
                    EventTypeId = table.Column<int>(nullable: false),
                    EventLocationId = table.Column<int>(nullable: false),
                    EventDateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventIds_EventDates_EventDateId",
                        column: x => x.EventDateId,
                        principalTable: "EventDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventIds_EventLocations_EventLocationId",
                        column: x => x.EventLocationId,
                        principalTable: "EventLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventIds_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventIds_EventDateId",
                table: "EventIds",
                column: "EventDateId");

            migrationBuilder.CreateIndex(
                name: "IX_EventIds_EventLocationId",
                table: "EventIds",
                column: "EventLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EventIds_EventTypeId",
                table: "EventIds",
                column: "EventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventIds");

            migrationBuilder.DropTable(
                name: "EventDates");

            migrationBuilder.DropTable(
                name: "EventLocations");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropSequence(
                name: "event_date_hilo");

            migrationBuilder.DropSequence(
                name: "event_hilo");

            migrationBuilder.DropSequence(
                name: "event_location_hilo");

            migrationBuilder.DropSequence(
                name: "event_types_hilo");
        }
    }
}
