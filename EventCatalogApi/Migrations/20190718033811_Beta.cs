using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogApi.Migrations
{
    public partial class Beta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventDates",
                table: "EventIds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventEndDate",
                table: "EventIds",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventEndTime",
                table: "EventIds",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventStartDate",
                table: "EventIds",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventStartTime",
                table: "EventIds",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "EventDates",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDates",
                table: "EventIds");

            migrationBuilder.DropColumn(
                name: "EventEndDate",
                table: "EventIds");

            migrationBuilder.DropColumn(
                name: "EventEndTime",
                table: "EventIds");

            migrationBuilder.DropColumn(
                name: "EventStartDate",
                table: "EventIds");

            migrationBuilder.DropColumn(
                name: "EventStartTime",
                table: "EventIds");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "EventDates",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
