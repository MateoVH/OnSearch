using Microsoft.EntityFrameworkCore.Migrations;

namespace OnSearch.Web.Migrations
{
    public partial class pruea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "ScheduleDatas");

            migrationBuilder.DropColumn(
                name: "IsAllDay",
                table: "ScheduleDatas");

            migrationBuilder.DropColumn(
                name: "IsRecurrence",
                table: "ScheduleDatas");

            migrationBuilder.DropColumn(
                name: "ProgramName",
                table: "ScheduleDatas");

            migrationBuilder.RenameColumn(
                name: "RecurrenceRule",
                table: "ScheduleDatas",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "ProgramStartTime",
                table: "ScheduleDatas",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "ProgramEndTime",
                table: "ScheduleDatas",
                newName: "EndTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "ScheduleDatas",
                newName: "RecurrenceRule");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "ScheduleDatas",
                newName: "ProgramStartTime");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "ScheduleDatas",
                newName: "ProgramEndTime");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "ScheduleDatas",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllDay",
                table: "ScheduleDatas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurrence",
                table: "ScheduleDatas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProgramName",
                table: "ScheduleDatas",
                nullable: true);
        }
    }
}
