using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimerCard.Migrations
{
    public partial class Log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attribution",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    classDescription = table.Column<string>(type: "TEXT", nullable: true),
                    collegeId = table.Column<string>(type: "TEXT", nullable: true),
                    majorId = table.Column<string>(type: "TEXT", nullable: true),
                    classId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<string>(type: "TEXT", nullable: true),
                    UName = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Creator = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Msg = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AttributionId = table.Column<string>(type: "TEXT", nullable: true),
                    StuId = table.Column<string>(type: "TEXT", nullable: true),
                    TeachName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    EmergencyContact = table.Column<string>(type: "TEXT", nullable: true),
                    MergencyPeoplePhone = table.Column<string>(type: "TEXT", nullable: true),
                    Langtineadress = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attribution");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
