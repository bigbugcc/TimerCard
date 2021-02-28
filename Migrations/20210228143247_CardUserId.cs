using Microsoft.EntityFrameworkCore.Migrations;

namespace TimerCard.Migrations
{
    public partial class CardUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardLog_User_UsersIdId",
                table: "CardLog");

            migrationBuilder.RenameColumn(
                name: "UsersIdId",
                table: "CardLog",
                newName: "UIdId");

            migrationBuilder.RenameIndex(
                name: "IX_CardLog_UsersIdId",
                table: "CardLog",
                newName: "IX_CardLog_UIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardLog_User_UIdId",
                table: "CardLog",
                column: "UIdId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardLog_User_UIdId",
                table: "CardLog");

            migrationBuilder.RenameColumn(
                name: "UIdId",
                table: "CardLog",
                newName: "UsersIdId");

            migrationBuilder.RenameIndex(
                name: "IX_CardLog_UIdId",
                table: "CardLog",
                newName: "IX_CardLog_UsersIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardLog_User_UsersIdId",
                table: "CardLog",
                column: "UsersIdId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
