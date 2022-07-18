using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddImageToCourier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Couriers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_ImageId",
                table: "Couriers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Couriers_Images_ImageId",
                table: "Couriers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Couriers_Images_ImageId",
                table: "Couriers");

            migrationBuilder.DropIndex(
                name: "IX_Couriers_ImageId",
                table: "Couriers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Couriers");
        }
    }
}
