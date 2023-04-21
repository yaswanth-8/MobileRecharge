using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileRecharge.Data.Migrations
{
    public partial class customeradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "History");

            migrationBuilder.AddColumn<string>(
                name: "CustomerIdId",
                table: "History",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_History_CustomerIdId",
                table: "History",
                column: "CustomerIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_AspNetUsers_CustomerIdId",
                table: "History",
                column: "CustomerIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_AspNetUsers_CustomerIdId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_CustomerIdId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "CustomerIdId",
                table: "History");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
