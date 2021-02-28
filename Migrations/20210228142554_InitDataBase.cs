using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimerCard.Migrations
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardLog",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    PlayTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlayStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayStatusAgain = table.Column<int>(type: "INTEGER", nullable: false),
                    EmailStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StuId = table.Column<string>(type: "TEXT", nullable: true),
                    Discipline = table.Column<string>(type: "TEXT", nullable: true),
                    TeachName = table.Column<string>(type: "TEXT", nullable: true),
                    Temperature = table.Column<double>(type: "REAL", nullable: false),
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
                name: "CardLog");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
