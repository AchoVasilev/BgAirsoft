using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddGunsToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "Guns",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guns_OrderId",
                table: "Guns",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guns_Orders_OrderId",
                table: "Guns",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guns_Orders_OrderId",
                table: "Guns");

            migrationBuilder.DropIndex(
                name: "IX_Guns_OrderId",
                table: "Guns");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Guns");
        }
    }
}
