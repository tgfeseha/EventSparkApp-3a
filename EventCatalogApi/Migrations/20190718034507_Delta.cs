using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class Delta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventEndDate",
                table: "EventIds");

            migrationBuilder.DropColumn(
                name: "EventStartDate",
                table: "EventIds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventEndDate",
                table: "EventIds",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventStartDate",
                table: "EventIds",
                nullable: false,
                defaultValue: "");
        }
    }
}
