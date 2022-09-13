using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnSearch.Web.Migrations
{
    public partial class pd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProgramName = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    ProgramStartTime = table.Column<DateTime>(nullable: false),
                    ProgramEndTime = table.Column<DateTime>(nullable: false),
                    IsAllDay = table.Column<bool>(nullable: false),
                    IsRecurrence = table.Column<bool>(nullable: false),
                    RecurrenceRule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleDatas");
        }
    }
}
